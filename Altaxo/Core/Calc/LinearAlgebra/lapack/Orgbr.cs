/*
 * Orgbr.cs
 * 
 * Copyright (c) 2003-2004, dnAnalytics. All rights reserved.
*/

#if !MANAGED
using System;
using System.Runtime.InteropServices;



namespace Altaxo.Calc.LinearAlgebra.Lapack{
	[System.Security.SuppressUnmanagedCodeSecurityAttribute]
	internal sealed class Orgbr {
		private  Orgbr() {}                           
		private static void ArgumentCheck( Vector vect, int m, int n, int k, Object A, int lda, Object tau ) {
			if ( A == null ) {
				throw new ArgumentNullException("A","A cannot be null.");
			}
			if ( tau == null ) {
				throw new ArgumentNullException("tau","tau cannot be null.");
			}
			if ( m<0 ) {
				throw new ArgumentException("m must be at least zero.", "m");
			}
			if ( n<0 ) {
				throw new ArgumentException("n must be at least zero.", "n");
			}

			if ( k<0 ) {
				throw new ArgumentException("k must be at least zero.", "k");
			}

			if( vect == Vector.Q ){
				if( m > k ){
					if( k > n ){
						throw new ArgumentException("k must be lest than n.");
					}
					if( n > m ){
						throw new ArgumentException("n must be lest than m.");
					}
				}else{
					if( m != n ){
						throw new ArgumentException("m and n must be equal.");
					}
				}
			}else{
				if( n > k ){
					if( k > m ){
						throw new ArgumentException("k must be lest than m.");
					}
					if( m > n ){
						throw new ArgumentException("m must be lest than n.");
					}
				}else{
					if( m != n ){
						throw new ArgumentException("m and n must be equal.");
					}
				}
			}
			if ( lda < System.Math.Max(1,m) ) {
				throw new ArgumentException("lda must be at least max(1,m)");
			}
		}
		
		
		
		internal static int Compute( Vector vect, int m, int n, int k, float[] A, int lda, float[] tau ){
			ArgumentCheck(vect, m, n, k, A, lda, tau);
			if (tau.Length < System.Math.Max(1, System.Math.Min(m, k))){
				throw new ArgumentException("tau must be at least max(1,min(m,k)).");
			}
			
			return dna_lapack_sorgbr(Configuration.BlockSize, vect, m, n, k, A, lda, tau);
		}

		internal static int Compute( Vector vect, int m, int n, int k, double[] A, int lda, double[] tau ){
			ArgumentCheck(vect, m, n, k, A, lda, tau);
			if (tau.Length < System.Math.Max(1, System.Math.Min(m, k))){
				throw new ArgumentException("tau must be at least max(1,min(m,k)).");
			}
			
			return dna_lapack_dorgbr(Configuration.BlockSize, vect, m, n, k, A, lda, tau);
		}

		[DllImport(Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_sorgbr( int block_size, Vector vect, int m, int n, int k, [In,Out]float[] A, int lda, [In,Out]float[] tau  );
	
		[DllImport(Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_dorgbr( int block_size, Vector vect, int m, int n, int k, [In,Out]double[] A, int lda, [In,Out]double[] tau   );
	}
}
#endif