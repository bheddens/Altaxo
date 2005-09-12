/*
 * Gesv.cs
 * 
 * Copyright (c) 2003-2004, dnAnalytics. All rights reserved.
*/
#if !MANAGED
using System;
using System.Runtime.InteropServices;

using dnA.Utility;

namespace dnA.Math.Lapack{
	[System.Security.SuppressUnmanagedCodeSecurityAttribute]
	internal sealed class Gesv {
		private  Gesv() {}                           
		private static void ArgumentCheck(int n, int nrhs, Object A, int lda, Object B, int ldb) {
			if ( A == null ) {
				throw new ArgumentNullException("A","A cannot be null.");
			}
			if ( B == null ) {
				throw new ArgumentNullException("B","B cannot be null.");
			}
			if ( n<0 ) {
				throw new ArgumentException("n must be at least zero.","n");
			}
			if ( nrhs<0 ) {
				throw new ArgumentException("nrhs must be at least zero.", "nrhs");
			}
			if ( lda < System.Math.Max(1,n) ) {
				throw new ArgumentException("lda must be at least max(1,n)", "lda");
			}
			if ( ldb < System.Math.Max(1,n) ) {
				throw new ArgumentException("ldb must be at least max(1,n)", "ldb");
			}
		}
	
		internal static int Compute( int n, int nrhs, float[] A, int lda, out int[] ipiv, float[] B, int ldb ){
			ArgumentCheck(n, nrhs, A, lda,  B, ldb);
			ipiv = new int[System.Math.Max(1, System.Math.Min(1,n))];			
			
			return dna_lapack_sgesv(n,nrhs,A,lda,ipiv,B,ldb);
		}

		internal static int Compute( int n, int nrhs, double[] A, int lda, out int[] ipiv, double[] B, int ldb ){
			ArgumentCheck(n, nrhs, A, lda,  B, ldb);
			ipiv = new int[System.Math.Max(1, System.Math.Min(1,n))];

			return dna_lapack_dgesv(n,nrhs,A,lda,ipiv,B,ldb);
		}

		internal static int Compute( int n, int nrhs, ComplexFloat[] A, int lda, out int[] ipiv, ComplexFloat[] B, int ldb ){
			ArgumentCheck(n, nrhs, A, lda,  B, ldb);
			ipiv = new int[System.Math.Max(1, System.Math.Min(1,n))];
			
			return dna_lapack_cgesv(n,nrhs,A,lda,ipiv,B,ldb);
		}

		internal static int Compute( int n, int nrhs, ComplexDouble[] A, int lda, out int[] ipiv, ComplexDouble[] B, int ldb ){
			ArgumentCheck(n, nrhs, A, lda,  B, ldb);
			ipiv = new int[System.Math.Max(1, System.Math.Min(1,n))];
			
			return dna_lapack_zgesv(n,nrhs,A,lda,ipiv,B,ldb);
		}

		[DllImport(dnA.Utility.Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_sgesv( int n, int nrhs, [In,Out]float[] A, int lda, [In,Out]int[] ipiv, [In,Out]float[] B, int ldb );
	
		[DllImport(dnA.Utility.Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_dgesv( int n, int nrhs, [In,Out]double[] A, int lda, [In,Out]int[] ipiv, [In,Out]double[] B, int ldb );

		[DllImport(dnA.Utility.Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_cgesv( int n, int nrhs, [In,Out]ComplexFloat[] A, int lda, [In,Out]int[] ipiv, [In,Out]ComplexFloat[] B, int ldb );

		[DllImport(dnA.Utility.Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_zgesv( int n, int nrhs, [In,Out]ComplexDouble[] A, int lda, [In,Out]int[] ipiv, [In,Out]ComplexDouble[] B, int ldb );
	}
}
#endif