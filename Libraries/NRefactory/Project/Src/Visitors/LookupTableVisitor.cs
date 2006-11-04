// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="none" email=""/>
//     <version>$Revision: 1611 $</version>
// </file>

using System;
using System.Collections.Generic;

using ICSharpCode.NRefactory.Ast;

namespace ICSharpCode.NRefactory.Visitors
{
	public class LocalLookupVariable
	{
		TypeReference typeRef;
		Location startPos;
		Location endPos;
		bool  isConst;
		
		public TypeReference TypeRef {
			get {
				return typeRef;
			}
		}
		public Location StartPos {
			get {
				return startPos;
			}
		}
		public Location EndPos {
			get {
				return endPos;
			}
		}
		
		public bool IsConst {
			get {
				return isConst;
			}
		}
		
		public LocalLookupVariable(TypeReference typeRef, Location startPos, Location endPos, bool isConst)
		{
			this.typeRef = typeRef;
			this.startPos = startPos;
			this.endPos = endPos;
			this.isConst = isConst;
		}
	}
	
	public class LookupTableVisitor : AbstractAstVisitor
	{
		Dictionary<string, List<LocalLookupVariable>> variables;
		
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public Dictionary<string, List<LocalLookupVariable>> Variables {
			get {
				return variables;
			}
		}
		
		List<WithStatement> withStatements = new List<WithStatement>();
		
		public List<WithStatement> WithStatements {
			get {
				return withStatements;
			}
		}
		
		public LookupTableVisitor(StringComparer nameComparer)
		{
			variables = new Dictionary<string, List<LocalLookupVariable>>(nameComparer);
		}
		
		public void AddVariable(TypeReference typeRef, string name, Location startPos, Location endPos, bool isConst)
		{
			if (name == null || name.Length == 0) {
				return;
			}
			List<LocalLookupVariable> list;
			if (!variables.ContainsKey(name)) {
				variables[name] = list = new List<LocalLookupVariable>();
			} else {
				list = (List<LocalLookupVariable>)variables[name];
			}
			list.Add(new LocalLookupVariable(typeRef, startPos, endPos, isConst));
		}
		
		public override object VisitWithStatement(WithStatement withStatement, object data)
		{
			withStatements.Add(withStatement);
			return base.VisitWithStatement(withStatement, data);
		}
		
		Stack<BlockStatement> blockStack = new Stack<BlockStatement>();
		
		public override object VisitBlockStatement(BlockStatement blockStatement, object data)
		{
			blockStack.Push(blockStatement);
			base.VisitBlockStatement(blockStatement, data);
			blockStack.Pop();
			return null;
		}
		
		public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
		{
			for (int i = 0; i < localVariableDeclaration.Variables.Count; ++i) {
				VariableDeclaration varDecl = (VariableDeclaration)localVariableDeclaration.Variables[i];
				
				AddVariable(localVariableDeclaration.GetTypeForVariable(i),
				            varDecl.Name,
				            localVariableDeclaration.StartLocation,
				            (blockStack.Count == 0) ? new Location(-1, -1) : blockStack.Peek().EndLocation,
				            (localVariableDeclaration.Modifier & Modifiers.Const) == Modifiers.Const);
			}
			return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
		}
		
		public override object VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression, object data)
		{
			foreach (ParameterDeclarationExpression p in anonymousMethodExpression.Parameters) {
				AddVariable(p.TypeReference, p.ParameterName, anonymousMethodExpression.StartLocation, anonymousMethodExpression.EndLocation, false);
			}
			return base.VisitAnonymousMethodExpression(anonymousMethodExpression, data);
		}
		
		// ForStatement and UsingStatement use a LocalVariableDeclaration,
		// so they don't need to be visited separately
		
		public override object VisitForeachStatement(ForeachStatement foreachStatement, object data)
		{
			AddVariable(foreachStatement.TypeReference,
			            foreachStatement.VariableName,
			            foreachStatement.StartLocation,
			            foreachStatement.EndLocation,
			            false);
			
			if (foreachStatement.Expression != null) {
				foreachStatement.Expression.AcceptVisitor(this, data);
			}
			if (foreachStatement.EmbeddedStatement == null) {
				return data;
			}
			return foreachStatement.EmbeddedStatement.AcceptVisitor(this, data);
		}
		
		
		
		public override object VisitTryCatchStatement(TryCatchStatement tryCatchStatement, object data)
		{
			if (tryCatchStatement == null) {
				return data;
			}
			if (tryCatchStatement.StatementBlock != null) {
				tryCatchStatement.StatementBlock.AcceptVisitor(this, data);
			}
			if (tryCatchStatement.CatchClauses != null) {
				foreach (CatchClause catchClause in tryCatchStatement.CatchClauses) {
					if (catchClause != null) {
						if (catchClause.TypeReference != null && catchClause.VariableName != null) {
							AddVariable(catchClause.TypeReference,
							            catchClause.VariableName,
							            catchClause.StatementBlock.StartLocation,
							            catchClause.StatementBlock.EndLocation,
							            false);
						}
						catchClause.StatementBlock.AcceptVisitor(this, data);
					}
				}
			}
			if (tryCatchStatement.FinallyBlock != null) {
				return tryCatchStatement.FinallyBlock.AcceptVisitor(this, data);
			}
			return data;
		}
	}
}