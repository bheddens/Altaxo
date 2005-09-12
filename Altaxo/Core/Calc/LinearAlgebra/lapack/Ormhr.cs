/*
 * Ormhr.cs
 * 
 * Copyright (c) 2003-2004, dnAnalytics. All rights reserved.
*/

#if !MANAGED
using System;
using System.Runtime.InteropServices;

using dnA.Utility;

namespace dnA.Math.Lapack{
	[System.Security.SuppressUnmanagedCodeSecurityAttribute]
	internal sealed class Ormhr {
		private  Ormhr() {}                           
		private static void ArgumentCheck(Side side, int m, int n, int k, int ilo, int ihi, Object A, int lda, Object tau, Object C, int ldc) {
			if ( A == null ) {
				throw new ArgumentNullException("A","A cannot be null.");
			}
			if ( tau == null ) {
				throw new ArgumentNullException("tau","tau cannot be null.");
			}
			if ( C == null ) {
				throw new ArgumentNullException("C","C cannot be null.");
			}
			if ( m<0 ) {
				throw new ArgumentException("m must be at least zero.", "m");
			}
			if ( n<0 ) {
				throw new ArgumentException("n must be at least zero.", "n");
			}
			if( side == Side.Left ){
				if( k < 0 || k > m ){
					throw new ArgumentException("k must be positive and less than or equal to m.", "k");
				}
				if (m>0) {
					if (ilo<1 || ilo>m || ilo>ihi)
						throw new ArgumentException("ilo must be a positive number and less than or equal to min(ihi,m) if m>0");
					if (ihi<1 || ihi>m)
						throw new ArgumentException("ihi must be between 1 and m if m>0");
				} else {
					if (ilo!=1)
						throw new ArgumentException("ilo must be 1 if m=0");
					if (ihi!=0)
						throw new ArgumentException("ihi must be 0 if m=0");
				}
			}else{
				if( k < 0 || k > n ){
					throw new ArgumentException("k must be positive and less than or equal to n.", "k");
				}
				if (n>0) {
					if (ilo<1 || ilo>n || ilo>ihi)
						throw new ArgumentException("ilo must be a positive number and less than or equal to min(ihi,n) if n>0");
					if (ihi<1 || ihi>n)
						throw new ArgumentException("ihi must be a positive number and less than or equal to n if n>0");
				} else {
					if (ilo!=1)
						throw new ArgumentException("ilo must be 1 if n=0", "ilo");
					if (ihi!=0)
						throw new ArgumentException("ihi must be 0 if n=0", "ihi");
				}
			}
			if( side == Side.Left ){
				if ( lda < System.Math.Max(1,m) ) {
					throw new ArgumentException("lda must be at least max(1,m)", "lda");
				}
			}else{
				if ( lda < System.Math.Max(1,n) ) {
					throw new ArgumentException("lda must be at least max(1,n)", "lda");
				}
			}
			if ( ldc < System.Math.Max(1,m) ) {
				throw new ArgumentException("ldc must be at least max(1,m)", "ldc");
			}			
		}

		internal static int Compute( Side side, Transpose trans, int m, int n, int k, int ilo, int ihi, ComplexFloat[] A, int lda, ComplexFloat[] tau, ComplexFloat[] C, int ldc  ){
			ArgumentCheck(side, m, n, k, ilo, ihi, A, lda, tau, C, ldc);
			if (tau.Length < System.Math.Max(1, k) ){
				throw new ArgumentException("tau must be at least max(1,k).");
			}
			
			return dna_lapack_cormhr(Configuration.BlockSize, side, trans, m, n, k, ilo, ihi, A, lda, tau, C, ldc);
		}

		internal static int Compute( Side side, Transpose trans, int m, int n, int k, int ilo, int ihi, ComplexDouble[] A, int lda, ComplexDouble[] tau, ComplexDouble[] C, int ldc  ){
			ArgumentCheck(side, m, n, k, ilo, ihi, A, lda, tau, C, ldc);
			if (tau.Length < System.Math.Max(1, k) ){
				throw new ArgumentException("tau must be at least max(1,k).");
			}
			
			return dna_lapack_zormhr(Configuration.BlockSize, side, trans, m, n, k, ilo, ihi, A, lda, tau, C, ldc);
		}

		[DllImport(dnA.Utility.Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_cormhr( int block_size, Side side, Transpose trans, int m, int n, int k, int ilo, int ihi, [In,Out]ComplexFloat[] A, int lda, [In,Out]ComplexFloat[] tau, [In,Out]ComplexFloat[] C, int ldc   );

		[DllImport(dnA.Utility.Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_zormhr( int block_size, Side side, Transpose trans, int m, int n, int k, int ilo, int ihi, [In,Out]ComplexDouble[] A, int lda, [In,Out]ComplexDouble[] tau, [In,Out]ComplexDouble[] C, int ldc   );
	}
}
#endif