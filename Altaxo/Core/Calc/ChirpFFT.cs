#region Copyright
/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2004 Dr. Dirk Lellinger
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
#endregion

using System;



namespace Altaxo.Calc.FFT
{
  /// <summary>
  /// Provides a method to perform a Fourier transformation of arbirtrary length.
  /// </summary>
  /// <remarks>The following code is adopted from the FFT library, see www.jjj.de.</remarks>
  public class ChirpFFT
  {
    
    static void CopyFromComplexToSplittedArrays(double[] destreal, double[] destimag, Complex[] src, int count)
    {
      for(int i=0;i<count;i++)
      {
        destreal[i]=src[i].Re;
        destimag[i]=src[i].Im;
      }
    }

    static void CopyFromSplittedArraysToComplex(Complex[] dest, double[] srcreal, double[] srcimag, int count)
    {
      for(int i=0;i<count;i++)
      {
        dest[i].Re = srcreal[i];
        dest[i].Im = srcimag[i];
      }
    }

    static void MultiplySplittedComplexArrays(double[] resreal, double[] resimag,
      double[] arr1real, double[] arr1imag, double[] arr2real, double[] arr2imag, int count)
    {
      for(int i=0;i<count;i++)
      {
                                
        double real = arr1real[i]*arr2real[i] - arr1imag[i]*arr2imag[i];
        double imag = arr1real[i]*arr2imag[i] + arr1imag[i]*arr2real[i];
        resreal[i]=real;
        resimag[i]=imag;
      }
    }

    static void NormalizeArrays(double[] arr1, double[] arr2, double factor, int count)
    {
      for(int i=0;i<count;i++)
      {
        arr1[i]*=factor;
        arr2[i]*=factor;
      }
    }


   static void fhtconvolution( Complex[] resarray,
     Complex[] arr1, Complex[] arr2, int arrsize)
  {
    double[] fht1real = new double[arrsize];
    double[] fht1imag = new double[arrsize];
    double[] fht2real = new double[arrsize];
    double[] fht2imag = new double[arrsize];

    CopyFromComplexToSplittedArrays(fht1real,fht1imag,arr1,arrsize);
    CopyFromComplexToSplittedArrays(fht2real,fht2imag,arr2,arrsize);

    // do a convolution by fourier transform both parts, multiply and inverse fft
    FastHartleyTransform.fht_fft(arrsize, fht1real, fht1imag);
     FastHartleyTransform.fht_fft(arrsize, fht2real, fht2imag);
    MultiplySplittedComplexArrays(fht1real, fht1imag, fht1real, fht1imag, fht2real, fht2imag, arrsize);
     FastHartleyTransform.fht_ifft(arrsize, fht1real,fht1imag);
    NormalizeArrays(fht1real, fht1imag, 1.0/arrsize, arrsize);
    CopyFromSplittedArraysToComplex(resarray,fht1real,fht1imag,arrsize);
	
   
  }

   

// der Chirpalgorithmus funktioniert auch noch bei arrsize=1+2^n mit der nächstgelegenen Potenz 2^(n+1) !!!

    public static void chirpnativefft(Complex[] result, Complex[] arr, int arrsize, bool bBackward)
    {
      int phasesign = bBackward ? 1 : -1;
     
      if(arrsize<=2)
        throw new ArgumentException("This algorithm works for array sizes > 2 only.");

      int ldnn = 2+ld((uint)(arrsize-2));
      int msize = (1<<ldnn);
      
      Complex[] xjfj = new Complex[msize];
      Complex[] fserp = new Complex[msize];
      Complex[] resarray = new Complex[msize];
      Complex[] cmparray = new Complex[arrsize];

      // fillArray(xjfj,std::complex<double>(0,0),msize);
      // fillArray(fserp,std::complex<double>(0,0),msize);
      // fillArray(resarray,std::complex<double>(0,0),msize);

      // bilde xj*fj
      for(int i=0;i<arrsize;i++)
      {
        double phi = phasesign * Math.PI*((i*i)%(2*arrsize))/arrsize;
        Complex val = new Complex(Math.Cos(phi),Math.Sin(phi));
        xjfj[i] = arr[i] * val;
      }

      // fill positive and negative part of fserp
      fserp[0]=new Complex(1,0);
      for(int i=1;i<arrsize;i++)
      {
        double phi = -phasesign * Math.PI*((i*i)%(2*arrsize))/arrsize;
        fserp[i].Re = fserp[msize-i].Re = Math.Cos(phi);
        fserp[i].Im = fserp[msize-i].Im = Math.Sin(phi);
      }

      //printArray("fserp",fserp,msize);


      // convolute xjfj with fserp
      //NativeCyclicConvolution(resarray,xjfj,fserp,msize);
      fhtconvolution(resarray,xjfj,fserp,msize);
      //printArray("Result of convolution",resarray,msize);

      // multipliziere mit fserpschlange
      for(int i=0;i<arrsize;i++)
      {
        double phi = phasesign * Math.PI*((i*i)%(2*arrsize))/arrsize;
        result[i] = resarray[i]* new Complex(Math.Cos(phi),Math.Sin(phi));
      }



    }


    /// <summary>
    /// Performs an FFT of arbitrary length by the chirp method. Use this method only if no other
    /// FFT is applicable.
    /// </summary>
    /// <param name="x">Array of real values.</param>
    /// <param name="y">Array of imaginary values.</param>
    /// <param name="n">Number of points to transform.</param>
    /// <param name="backward">If false, a forward FFT is performed. If true, a inverse FFT is performed.</param>
    public static void
      FFT(double[] x, double[] y, uint n, bool backward)
    {
      Complex[] arr = new Complex[n];
      CopyFromSplittedArraysToComplex(arr,x,y,(int)n);
      Complex[] result = new Complex[n];
      chirpnativefft(result,arr,(int)n, backward);
      CopyFromComplexToSplittedArrays(x,y,result,(int)n);

    }



    static void make_fft_chirp(double[] wr, double[] wi, uint n, bool backward)
    {

      double phi = backward ? -Math.PI/n : Math.PI/n;

      uint n2 = 2*n;
      for (uint np=0,k=0; k<n; ++k)
      {
        double c = Math.Cos(phi*np);
        double s = Math.Sin(phi*np);

        np += ((k<<1)+1);  // np == (k*k)%n2

        if ( np>=n2 ) 
          np -= n2;

        wr[k] = c;
        wi[k] = s;
      }
    }


    static void complete_fft_chirp(double[] wr, double[] wi, uint n, uint nn)
    {
      if ( (n&1)!=0 )  // n odd
      {
        for (uint k=n; k<nn; ++k)  
          wr[k] = -wr[k-n];
        for (uint k=n; k<nn; ++k)
          wi[k] = -wi[k-n];
      }
      else
      {
        for (uint k=n; k<nn; ++k)
          wr[k] = wr[k-n];
        for (uint k=n; k<nn; ++k)
          wi[k] = wi[k-n];
      }
    }
   
    static void make_fft_fract_chirp(double[] wr, double[] wi, double v, uint n, uint nn)
    {
      double phi = v*Math.PI/n;

      uint n2 = 2*n;
      uint np=0;
      for (uint k=0; k<nn; ++k)
      {
        double c = Math.Cos(phi*np);
        double s = Math.Sin(phi*np);
      
        np += ((k<<1)+1);  // np == (k*k)%n2
        if ( np>=n2 ) 
          np -= n2;

        wr[k] = c;
        wi[k] = s;
      }
    }

    static void cmult(double c, double s, ref double u, ref double v)
    {
      double t = u*s+v*c;  
      u *= c;  
      u -= v*s; 
      v = t; 
    }

    // complex multiply array g[] by f[]:
    //  Complex(gr[],gi[]) *= Complex(fr[],fi[])
    static void ri_multiply(double[] fr, double[] fi, double[] gr, double[] gi, uint n)
    {
      while ( (n--)!=0 )  cmult(fr[n], fi[n], ref gr[n], ref gi[n]);
    }

    static void negate(double[] f, uint n)
      // negate every element of f[]
    {
      while ( (n--)!=0 )  f[n] = -f[n];
    }

    /// <summary>
    /// Returns k so that 2^k &lt;= x &lt; 2^(k+1). If x==0 then 0 is returned.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns>A number k so that 2^k &lt;= x &lt; 2^(k+1). If x==0 then 0 is returned.</returns>
    static int ld(uint x)
    {
      if ( 0==x )  return  0;

      int r = 0;
      if ( (x & 0xffff0000)!=0 )  { x >>= 16;  r += 16; }
      if ( (x & 0x0000ff00)!=0 )  { x >>=  8;  r +=  8; }
      if ( (x & 0x000000f0)!=0 )  { x >>=  4;  r +=  4; }
      if ( (x & 0x0000000c)!=0 )  { x >>=  2;  r +=  2; }
      if ( (x & 0x00000002)!=0 )  {            r +=  1; }
      return r;
    }

    /// <summary>
    /// Returns k so that 2^k &lt;= x &lt; 2^(k+1).
    /// If x==0 then 0 is returned.
    /// </summary>
    /// <param name="x">The argument.</param>
    /// <returns>A number k so that 2^k &lt;= x &lt; 2^(k+1). If x==0 then 0 is returned.</returns>
    static int ld(ulong x)
    {
      if ( 0==x )  return  0;

      int r = 0;
      if ( (x & (~0UL<<32))!=0 )  { x >>= 32;  r += 32; }
      if ( (x & 0xffff0000)!=0 )  { x >>= 16;  r += 16; }
      if ( (x & 0x0000ff00)!=0 )  { x >>=  8;  r +=  8; }
      if ( (x & 0x000000f0)!=0 )  { x >>=  4;  r +=  4; }
      if ( (x & 0x0000000c)!=0 )  { x >>=  2;  r +=  2; }
      if ( (x & 0x00000002)!=0 )  {            r +=  1; }
      return r;
    }

    static void
      fft_complex_convolution(double[] fr, double[] fi,
      double[] gr, double[] gi,
      uint ldn, double v /*=0.0*/ )
      //
      // (complex, cyclic) convolution:  (gr,gi)[] :=  (fr,fi)[] (*) (gr,gi)[]
      // (use zero padded data for usual conv.)
      // ldn := base-2 logarithm of the array length
      //
      // supply a value for v for a normalization factor != 1/n
      //
    {
      // const int is = 1;
      int n = (1<<(int)ldn);

      FastHartleyTransform.fht_fft(n,fr,fi); //FFT(fr, fi, ldn, is);
      FastHartleyTransform.fht_fft(n,gr,gi); //FFT(gr, gi, ldn, is);

      if ( v==0.0 )  v = 1.0/n;
      for (uint k=0; k<n; ++k)
      {
        double tr = fr[k];
        double ti = fi[k];
        cmult(gr[k], gi[k], ref tr, ref ti);
        gr[k] = tr * v;
        gi[k] = ti * v;

        cmult(fr[k], fi[k], ref gr[k], ref gi[k]);
      }

      FastHartleyTransform.fht_ifft(n,gr,gi); // FFT(gr, gi, ldn, -is);
    }


    /// <summary>
    /// Performs an FFT of arbitrary length by the chirp method. Use this method only if no other
    /// FFT is applicable.
    /// </summary>
    /// <param name="x">Array of real values.</param>
    /// <param name="y">Array of imaginary values.</param>
    /// <param name="n">Number of points to transform.</param>
    /// <param name="backward">If false, a forward FFT is performed. If true, a inverse FFT is performed.</param>
    static void
      FFT_DONTUSEIT(double[] x, double[] y, uint n, bool backward)
      //
      // arbitrary length fft
      //
    {
      int ldnn = ld(n);
      if ( n==(1U<<ldnn) )  ldnn += 1;
      else                   ldnn += 2;
      uint nn = (1U<<ldnn);

      // allocate temporary arrays
      double[] fr = new double[nn];
      double[] fi = new double[nn];

      //    ri_copy(x,y,fr,fi,n);
      Array.Copy(x,0,fr,0,n);
      Array.Copy(y,0,fi,0,n);

      // note: the rest of the array is already zero, but in other languages it
      // must be set to zero here
      //null(fr+n, nn-n);
      //null(fi+n, nn-n);

      double[] wr = new double[nn];
      double[] wi = new double[nn];

      //    make_fft_fract_chirp(wr,wi,1.0*is,n,nn);
      make_fft_chirp(wr,wi,n,backward);
      complete_fft_chirp(wr,wi,n,nn);

      ri_multiply(wr,wi,fr,fi,n);

      negate(wi,nn);
      fft_complex_convolution(wr,wi,fr,fi,(uint)ldnn,0);

      //    make_fft_fract_chirp(wr,wi,1.0*is,n,nn);
      make_fft_chirp(wr,wi,n,backward);
      complete_fft_chirp(wr,wi,n,nn);

      ri_multiply(fr,fi,wr,wi,nn);

      //    ri_copy(wr+n,wi+n,x,y,n);
      // copy(wr+n, x, n);
      // copy(wi+n, y, n);

      Array.Copy(wr,n,x,0,n);
      Array.Copy(wi,n,y,0,n);
    
    }


  }
}
