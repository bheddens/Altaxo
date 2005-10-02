/*
 * Gesvd.cs
 * 
 * Copyright (c) 2003-2004, dnAnalytics. All rights reserved.
*/
#if !MANAGED
using System;
using System.Runtime.InteropServices;



namespace Altaxo.Calc.LinearAlgebra.Lapack{
	[System.Security.SuppressUnmanagedCodeSecurityAttribute]
	internal sealed class Gesvd {
		private Gesvd() {}                           
	
		internal static int Compute( int m, int n, float[] a, float[] s, float[] u, float[] v ){
			if( a == null ){
				throw new ArgumentNullException("a", "a cannot be null.");
			}
			return dna_lapack_sgesvd(m, n, a, m, s, u, m, v, n);
		}

		internal static int Compute( int m, int n, double[] a, double[] s, double[] u, double[] v ){
			if( a == null ){
				throw new ArgumentNullException("a", "a cannot be null.");
			}
			return dna_lapack_dgesvd(m, n, a, m, s, u, m, v, n);
		}

		internal static int Compute( int m, int n, ComplexFloat[] a, float[] s, ComplexFloat[] u, ComplexFloat[] v  ){
			if( a == null ){
				throw new ArgumentNullException("a", "a cannot be null.");
			}
			return dna_lapack_cgesvd(m, n, a, m, s, u, m, v, n);
		}

		internal static int Compute( int m, int n, Complex[] a, double[] s, Complex[] u, Complex[] v  ){
			if( a == null ){
				throw new ArgumentNullException("a", "a cannot be null.");
			}
			return dna_lapack_zgesvd(m, n, a, m, s, u, m, v, n);
		}

		[DllImport(Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_sgesvd( int m, int n, [In,Out]float[] a, int lda, [In,Out]float[] s, [In,Out]float[] u, int ldu, [In,Out]float[] v, int ldavt );

		[DllImport(Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_dgesvd( int m, int n, [In,Out]double[] a, int lda, [In,Out]double[] s, [In,Out]double[] u, int ldu, [In,Out]double[] v, int ldavt );

		[DllImport(Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_cgesvd( int m, int n, [In,Out]ComplexFloat[] a, int lda, [In,Out]float[] s, [In,Out]ComplexFloat[] u, int ldu, [In,Out]ComplexFloat[] v, int ldavt );

		[DllImport(Configuration.BLASLibrary, ExactSpelling=true, SetLastError=false)]
		private static extern int dna_lapack_zgesvd( int m, int n, [In,Out]Complex[] a, int lda, [In,Out]double[] s, [In,Out]Complex[] u, int ldu, [In,Out]Complex[] v, int ldavt );
	}
}
#endif