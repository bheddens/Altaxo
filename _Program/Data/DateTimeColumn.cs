/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002 Dr. Dirk Lellinger
//
//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation; either version 2 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program; if not, write to the Free Software
//    Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
//
/////////////////////////////////////////////////////////////////////////////

using System;

namespace Altaxo.Data
{
	/// <summary>
	/// Summary description for Altaxo.Data.DateTimeColumn.
	/// </summary>
	public class DateTimeColumn : DataColumn
	{
		private DateTime[] m_Array;
		private int        m_Capacity; // shortcut to m_Array.Length;
		public static readonly DateTime NullValue = DateTime.MinValue; 
	
		public DateTimeColumn()
		{
		}

		public DateTimeColumn(string name)
			: base(name)
	{
	}
		public DateTimeColumn(Altaxo.Data.DataTable parenttable, string name)
			: base(parenttable,name)
	{
	}
	
		public DateTimeColumn(int initialcapacity)
		{
			m_Array = new DateTime[initialcapacity];
			m_Capacity = initialcapacity;
		}
				
		public override System.Type GetColumnStyleType()
		{
			return typeof(Altaxo.Worksheet.DateTimeColumnStyle);
		}

		protected internal DateTime GetValueDirect(int idx)
		{
			return m_Array[idx];
		}			
			
		public override void CopyDataFrom(Altaxo.Data.DataColumn v)
		{
			if(v.GetType()!=typeof(Altaxo.Data.DateTimeColumn))
			{
				throw new ArgumentException("Try to copy " + v.GetType() + " to " + this.GetType(),"v"); // throw exception
			}
			Altaxo.Data.DateTimeColumn vd = (Altaxo.Data.DateTimeColumn)v;	

			// suggestion, but __not__ implemented:
			// if v is a standalone column, then simply take the dataarray
			// otherwise: copy the data by value	
			int oldCount = this.m_Count;
			if(null==vd.m_Array || 0==vd.m_Count)
			{
				m_Array=null;
				m_Capacity=0;
				m_Count=0;
			}
			else
			{
				m_Array = (DateTime[])((Altaxo.Data.DateTimeColumn)v).m_Array.Clone();
				m_Capacity = m_Array.Length;
				m_Count = ((Altaxo.Data.DateTimeColumn)v).m_Count;
			}
			if(oldCount>0 || m_Count>0) // message only if really was a change
				NotifyDataChanged(0,oldCount>m_Count? (oldCount-1):(m_Count-1),m_Count<oldCount);
		}				
		protected void Realloc(int i)
		{
			int newcapacity1 = (int)(m_Capacity*increaseFactor+addSpace);
			int newcapacity2 = i+addSpace+1;
			int newcapacity = newcapacity1>newcapacity2 ? newcapacity1:newcapacity2;
				
			DateTime[] newarray = new DateTime[newcapacity];
			if(m_Count>0)
			{
				Array.Copy(m_Array,newarray,m_Count);
			}

			m_Array = newarray;
		}

		// indexers


		public override void SetValueAt(int i, AltaxoVariant val)
		{
			if(val.IsTypeOrNull(AltaxoVariant.Content.VDateTime))
				this[i] = (DateTime)val.m_Object;
			else
				throw new ApplicationException("Error: Try to set " + this.TypeAndName + "[" + i + "] with " + val.ToString());
		}

		public override AltaxoVariant GetVariantAt(int i)
		{
			return new AltaxoVariant(this[i]);
		}

		public override bool IsElementEmpty(int i)
		{
			return i<m_Count ? (DateTime.MinValue==m_Array[i]) : true;
		}


		public new DateTime this[int i]
		{
			get
			{
				if(i>=0 && i<m_Count)
					return m_Array[i];
				return DateTime.MinValue;	
			}
			set
			{
				bool bCountDecreased=false;

				if(value==DateTime.MinValue)
				{
					if(i>=0 && i<m_Count-1) // i is inside the used range
					{
						m_Array[i]=value;
					}
					else if(i==(m_Count-1)) // m_Count is then decreasing
					{
						for(m_Count=i; m_Count>0 && (DateTime.MinValue==m_Array[m_Count-1]); --m_Count);
						bCountDecreased=true;;
					}
				}
				else // value is a valid value
				{
					if(i>=0 && i<m_Count) // i is inside the used range

					{
						m_Array[i]=value;
					}
					else if(i==m_Count && i<m_Capacity) // i is the next value after the used range
					{
						m_Array[i]=value;
						m_Count=i+1;
					}
					else if(i>m_Count && i<m_Capacity) // is is outside used range, but inside capacity of array
					{
						for(int k=m_Count;k<i;k++)
							m_Array[k]=DateTime.MinValue; // fill range between used range and new element with voids
					
						m_Array[i]=value;
						m_Count=i+1;
					}
					else if(i>=0) // i is outside of capacity, then realloc the array
					{
						Realloc(i);

						for(int k=m_Count;k<i;k++)
							m_Array[k]=DateTime.MinValue; // fill range between used range and new element with voids
					
						m_Array[i]=value;
						m_Count=i+1;
					}
				}

			NotifyDataChanged(i,i,bCountDecreased);
			} // end set	
		} // end indexer



		public override void InsertRows(int nInsBeforeColumn, int nInsCount)
		{
			if(nInsCount<=0)
				return; // nothing to do

			int newlen = this.m_Count + nInsCount;
			if(newlen>m_Capacity)
				Realloc(newlen);

			// copy values from m_Count downto nBeforeColumn 
			for(int i=m_Count-1, j=newlen-1; i>=nInsBeforeColumn;i--,j--)
				m_Array[j] = m_Array[i];

			for(int i=nInsBeforeColumn+nInsCount-1;i>=nInsBeforeColumn;i++)
				m_Array[i]=NullValue;
		
			this.m_Count=newlen;
			this.NotifyDataChanged(nInsBeforeColumn,m_Count-1,false);
			}

		public override void RemoveRows(int nDelFirstRow, int nDelCount)
		{
			if(nDelCount<=0)
				return; // nothing to do here

			int i,j;
			for(i=nDelFirstRow,j=nDelFirstRow+nDelCount;j<m_Count;i++,i++)
				m_Array[i]=m_Array[j];
			m_Count=i;
			this.NotifyDataChanged(nDelFirstRow,m_Count-1,true);
			}

		public static Altaxo.Data.DateTimeColumn operator +(Altaxo.Data.DateTimeColumn c1, Altaxo.Data.DoubleColumn c2)
		{
			int len = c1.Count<c2.Count ? c1.Count : c2.Count;
			Altaxo.Data.DateTimeColumn c3 = new Altaxo.Data.DateTimeColumn(len);
			for(int i=0;i<len;i++)
			{
				c3.m_Array[i] = c1.m_Array[i].AddSeconds(c2.GetValueDirect(i));
			}
			
			
			c3.m_Count=len;
			
			return c3;	
		}

		public static Altaxo.Data.DateTimeColumn operator +(Altaxo.Data.DateTimeColumn c1, double c2)
		{
			int len = c1.m_Count;
			Altaxo.Data.DateTimeColumn c3 = new Altaxo.Data.DateTimeColumn(len);
			for(int i=0;i<len;i++)
			{
				c3.m_Array[i] = c1.m_Array[i].AddSeconds(c2);
			}

			
			
			c3.m_Count=len;

			return c3;	
		}


		public static Altaxo.Data.DoubleColumn operator -(Altaxo.Data.DateTimeColumn c1, Altaxo.Data.DateTimeColumn c2)
		{
		return Altaxo.Data.DoubleColumn.Subtraction(c1,c2);
		}


		public static Altaxo.Data.DateTimeColumn operator -(Altaxo.Data.DateTimeColumn c1, Altaxo.Data.DoubleColumn c2)
		{
			int len = c1.Count<c2.Count ? c1.Count : c2.Count;
			Altaxo.Data.DateTimeColumn c3 = new Altaxo.Data.DateTimeColumn(len);
			for(int i=0;i<len;i++)
			{
				c3.m_Array[i] = c1.m_Array[i].AddSeconds(-c2.GetValueDirect(i));
			}
			
			
			c3.m_Count=len;
			
			return c3;	
		}

		public static Altaxo.Data.DateTimeColumn operator -(Altaxo.Data.DateTimeColumn c1, double c2)
		{
			Altaxo.Data.DateTimeColumn c3 = new Altaxo.Data.DateTimeColumn(c1.m_Count);
			int len = c1.m_Count;
			for(int i=0;i<len;i++)
			{
				c3.m_Array[i] = c1.m_Array[i].AddSeconds(-c2);
			}

			
			
			c3.m_Count=len;

			return c3;	
		}
	}
}
