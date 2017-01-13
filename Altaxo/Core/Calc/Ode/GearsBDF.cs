﻿#region Copyright

// Copyright Microsoft Research in collaboration with Moscow State University
// Microsoft Research License, see license file "MSR-LA - Open Solving Library for ODEs.rtf"
// This file originates from project OSLO - Open solving libraries for ODEs - 1.1

// Modified by D. Lellinger 2017

#endregion Copyright

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Altaxo.Calc.Ode
{
	public class GearsBDF
	{
		/// <summary>
		/// Representation of current state in Nordsieck's method
		/// </summary>
		internal class NordsieckState
		{
			public double tn, dt, Dq, delta;

			/// <summary>Current method order, from 1 to qmax</summary>
			public int qn;

			/// <summary>Maximum method order, from 1 to 5</summary>
			public int qmax;

			/// <summary>Successfull steps count</summary>
			public int nsuccess;

			/// <summary>Step size scale factor/// </summary>
			public double rFactor;

			public Vector xn, en;
			public Matrix zn;
			public double epsilon = 1e-12;

			public void ChangeStep()
			{
				dt = dt / 2.0;
				if (dt < epsilon) throw new ArgumentException("Cannot generate numerical solution");
				zn = NordsieckState.Rescale(zn, 0.5d);
			}

			/// <summary>
			/// The following function rescales Nordsieck's matrix in more effective way than
			/// only compute two matrixes. Current algorithm is taken from book of
			/// Krishnan Radhakrishnan and Alan C.Hindmarsh "Description and Use of LSODE,
			/// the Livermore Solver of Ordinary Differential Equations"
			/// </summary>
			/// <param name="arg">Previous value of history matrix</param>
			/// <param name="r">(New time step)/(Old time step)</param>
			/// <returns>Rescaled history matrix</returns>
			public static Matrix Rescale(Matrix arg, double r)
			{
				Matrix res = (Matrix)arg.Clone(); ;
				double R = 1;
				int q = res.ColumnDimension;

				for (int j = 1; j < q; j++)
				{
					R = R * r;
					for (int i = 0; i < res.RowDimension; i++)
					{
						res[i, j] = res[i, j] * R;
					}
				}
				return res;
			}

			/// <summary>
			/// The following function compute Nordsieck's matrix Zn0 = Z(n-1)*A
			/// in more effective way than just multiply two matrixes.
			///  Current algoritm is taken from book of
			/// Krishnan Radhakrishnan and Alan C.Hindmarsh "Description and Use of LSODE,
			/// the Livermore Solver of Ordinary Differential Equations"
			/// </summary>
			/// <param name="arg">previous value of Nordsieck's matrix, so-called Z(n-1)</param>
			/// <returns>So-called Zn0,initial vaue of Z in new step</returns>
			public static Matrix ZNew(Matrix arg)
			{
				Matrix res = (Matrix)arg.Clone();
				int q = arg.ColumnDimension;
				int n = arg.RowDimension;

				for (int k = 0; k < q - 1; k++)
				{
					for (int j = q - 1; j > k; j--)
					{
						for (int i = 0; i < n; i++)
						{
							res[i, j - 1] = res[i, j] + res[i, j - 1];
						}
					}
				}

				return res;
			}

			/// <summary>Compute Jacobian</summary>
			/// <param name="f"></param>
			/// <param name="x"></param>
			/// <param name="t"></param>
			/// <returns></returns>
			public static Matrix Jacobian(Func<double, Vector, Vector> f, Vector x, double t)
			{
				int N = x.Length;
				Matrix J = new Matrix(N, N);

				Vector variation = Vector.Zeros(N);
				for (int i = 0; i < N; i++)
				{
					variation[i] = Math.Sqrt(1e-6 * Math.Max(1e-5, Math.Abs(x[i])));
				}

				Vector fold = f(t, x);

				Vector[] fnew = new Vector[N];
				for (int i = 0; i < N; i++)
				{
					x[i] = x[i] + variation[i];
					fnew[i] = f(t, x);
					x[i] = x[i] - variation[i];
				}
				for (int i = 0; i < N; i++)
				{
					for (int j = 0; j < N; j++)
					{
						J[i, j] = (fnew[j][i] - fold[i]) / (variation[j]);
					}
				}
				return J;
			}
		}

		// Vector l for Nordsieck algorithm (orders 1 to 5)
		private static double[][] l = new double[6][] {
						new double[] { 1, 1 },
						new double[] { 2 / 3d, 1, 1 / 3d },
						new double[] { 6 / 11d, 1, 6 / 11d, 1 / 11d },
						new double[] { 24 / 50d, 1, 35 / 50d, 10 / 50d, 1 / 50d },
						new double[] { 120 / 274d, 1, 225 / 274d, 85 / 274d, 15 / 274d, 1 / 274d },
						new double[] { 720 / 1764d, 1, 1624 / 1764d, 735 / 1764d, 175 / 1764d, 21 / 1764d, 1 / 1764d }
				};

		// Vector Beta for Nordsieck algorithm (orders 1 to 5)
		//private static double[] b = new double[] { 720 / 1764d, 1, 1624 / 1764d, 735 / 1764d, 175 / 1764d, 21 / 1764d, 1/1764d };
		private static double[] b = new double[] { 1.0d, 2.0d / 3.0d, 6.0d / 11.0d, 24.0d / 50.0d, 120.0d / 274.0d, 720.0 / 1764.0d };

		private NordsieckState currstate;
		private bool isIterationFailed;
		private int n;
		private Options opts;
		private double tout = double.NaN;
		private Func<double, Vector, Vector> f;
		private Vector xout;
		private double r;

		/// <summary>
		/// Initialize Gear's BDF method with dynamically changed step size and order. Order changes between 1 and 3.
		/// </summary>
		/// <param name="t0">Initial time point</param>
		/// <param name="y0">Initial values (at time <paramref name="t0"/>).</param>
		/// <param name="dydt">Evaluation function for the derivatives. First argument is the time, second argument are the current y values. The third argument is an array where the derivatives are expected to be placed into.</param>
		/// <returns>Sequence of infinite number of solution points.</returns>
		public void Initialize(double t0, double[] y0, Action<double, double[], double[]> dydt)
		{
			Initialize(t0, y0, dydt, Options.Default);
		}

		/// <summary>
		/// Initialize Gear's BDF method with dynamically changed step size and order. Order changes between 1 and 3.
		/// </summary>
		/// <param name="t0">Initial time point</param>
		/// <param name="y0">Initial values (at time <paramref name="t0"/>).</param>
		/// <param name="dydt">Evaluation function for the derivatives. First argument is the time, second argument are the current y values. The third argument is an array where the derivatives are expected to be placed into.</param>
		/// <param name="opts">Options for accuracy control and initial step size</param>
		public void Initialize(double t0, double[] y0, Action<double, double[], double[]> dydt, Options opts)
		{
			var adapter = new Adapter1(dydt, y0.Length);
			Initialize(t0, y0, adapter.EvaluateDyDt, opts);
		}

		[Obsolete]
		public void Initialize(double t0, Vector x0, Func<double, Vector, Vector> f)
		{
			Initialize(t0, x0, f, Options.Default);
		}

		private class Adapter1
		{
			private Action<double, double[], double[]> _func;
			//private Vector dydt;

			public Adapter1(Action<double, double[], double[]> ff, int dim)
			{
				_func = ff;
				//dydt = new Vector(new double[dim]);
			}

			public Vector EvaluateDyDt(double t, Vector y)
			{
				var dydt = new Vector(new double[y.Length]);
				_func(t, y.v, dydt.v);
				return dydt;
			}
		}

		/// <summary>
		/// Implementation of Gear's BDF method with dynamically changed step size and order. Order changes between 1 and 3.
		/// </summary>
		/// <param name="t0">Initial time point</param>
		/// <param name="x0">Initial phase vector</param>
		/// <param name="f">Right parts of the system</param>
		/// <param name="opts">Options for accuracy control and initial step size</param>
		/// <returns>Sequence of infinite number of solution points.</returns>
		[Obsolete]
		public void Initialize(double t0, Vector x0, Func<double, Vector, Vector> f, Options opts)
		{
			double t = t0;
			Vector x = x0.Clone();
			this.n = x0.Length;

			this.f = f;
			this.opts = opts;

			//Initial step size.
			Vector dx = f(t0, x0).Clone();
			double dt;
			if (opts.InitialStep != 0)
			{
				dt = opts.InitialStep;
			}
			else
			{
				var tol = opts.RelativeTolerance;
				var ewt = Vector.Zeros(n);
				var ywt = Vector.Zeros(n);
				var sum = 0.0;
				for (int i = 0; i < n; i++)
				{
					ewt[i] = opts.RelativeTolerance * Math.Abs(x[i]) + opts.AbsoluteTolerance;
					ywt[i] = ewt[i] / tol;
					sum = sum + (double)dx[i] * dx[i] / (ywt[i] * ywt[i]);
				}

				dt = Math.Sqrt(tol / ((double)1.0d / (ywt[0] * ywt[0]) + sum / n));
			}

			dt = Math.Min(dt, opts.MaxStep);
			var resdt = dt;

			int qmax = 5;
			int qcurr = 2;

			//Compute Nordstieck's history matrix at t=t0;
			Matrix zn = new Matrix(n, qmax + 1);
			for (int i = 0; i < n; i++)
			{
				zn[i, 0] = x[i];
				zn[i, 1] = dt * dx[i];
				for (int j = qcurr; j < qmax + 1; j++)
				{
					zn[i, j] = 0.0d;
				}
			}

			var eold = Vector.Zeros(n);

			currstate = new NordsieckState()
			{
				delta = 0.0d,
				Dq = 0.0d,
				dt = dt,
				en = eold,
				tn = t,
				xn = x0,
				qn = qcurr,
				qmax = qmax,
				nsuccess = 0,
				zn = zn,
				rFactor = 1.0d
			};
			isIterationFailed = false;

			this.tout = t0;
			this.xout = x0.Clone();

			// ---------------------------------------------------------------------------------------------------
			// End of initialize
			// ---------------------------------------------------------------------------------------------------

			// Firstly, return initial point
			Evaluate(t0, true);
		}

		public double[] Evaluate(double t_sol)
		{
			if (!(t_sol >= tout))
				throw new ArgumentOutOfRangeException(nameof(t_sol), "t must be greater than or equal than the last evaluated t");

			return Evaluate(t_sol, false);
		}

		private double[] Evaluate(double t_sol, bool isFirstEvaluation)
		{
			tout = t_sol;

			if (!isFirstEvaluation)
			{
				// we have to clone some of the code from below to here
				// this is no good style, but a goto statement with a jump inside another code block will not work here.
				// Output data
				if (currstate.tn <= tout && tout <= currstate.tn + currstate.dt)
				{
					return Vector.Lerp(tout, currstate.tn, xout, currstate.tn + currstate.dt, currstate.xn).v;
				}
				Vector.Copy(currstate.xn, xout);

				currstate.tn = currstate.tn + currstate.dt;

				if (opts.MaxStep < Double.MaxValue)
				{
					r = Math.Min(r, opts.MaxStep / currstate.dt);
				}

				if (opts.MinStep > 0)
				{
					r = Math.Max(r, opts.MinStep / currstate.dt);
				}

				r = Math.Min(r, opts.MaxScale);
				r = Math.Max(r, opts.MinScale);

				currstate.dt = currstate.dt * r;

				currstate.zn = NordsieckState.Rescale(currstate.zn, r);
			}

			//Can produce any number of solution points
			while (true)
			{
				// Reset fail flag
				isIterationFailed = false;

				// Predictor step
				var z0 = currstate.zn.Clone();
				currstate.zn = NordsieckState.ZNew(currstate.zn);
				currstate.en = Vector.Zeros(n);
				currstate.xn = currstate.zn.CloneColumn(0);

				// Corrector step
				currstate = PredictorCorrectorScheme(currstate, ref isIterationFailed, f, opts);

				if (isIterationFailed) // If iterations are not finished - bad convergence
				{
					currstate.zn = z0;
					currstate.nsuccess = 0;
					currstate.ChangeStep();
				}
				else // Iterations finished
				{
					r = Math.Min(1.1d, Math.Max(0.2d, currstate.rFactor));

					if (currstate.delta >= 1.0d)
					{
						if (opts.MaxStep < Double.MaxValue)
						{
							r = Math.Min(r, opts.MaxStep / currstate.dt);
						}

						if (opts.MinStep > 0)
						{
							r = Math.Max(r, opts.MinStep / currstate.dt);
						}

						r = Math.Min(r, opts.MaxScale);
						r = Math.Max(r, opts.MinScale);

						currstate.dt = currstate.dt * r; // Decrease step
						currstate.zn = NordsieckState.Rescale(currstate.zn, r);
					}
					else
					{
						// Output data
						if (currstate.tn <= tout && tout <= currstate.tn + currstate.dt)
						{
							return Vector.Lerp(tout, currstate.tn, xout, currstate.tn + currstate.dt, currstate.xn).v;
						}
						Vector.Copy(currstate.xn, xout);

						currstate.tn = currstate.tn + currstate.dt;

						if (opts.MaxStep < Double.MaxValue)
						{
							r = Math.Min(r, opts.MaxStep / currstate.dt);
						}

						if (opts.MinStep > 0)
						{
							r = Math.Max(r, opts.MinStep / currstate.dt);
						}

						r = Math.Min(r, opts.MaxScale);
						r = Math.Max(r, opts.MinScale);

						currstate.dt = currstate.dt * r;

						currstate.zn = NordsieckState.Rescale(currstate.zn, r);
					}
				}
			}
		}

		/// <summary>
		/// Compute factorial
		/// </summary>
		/// <param name="arg"></param>
		/// <returns></returns>
		internal static int Factorial(int arg)
		{
			if (arg < 0) return -1;
			if (arg == 0) return 1;
			return arg * Factorial(arg - 1);
		}

		/// <summary>
		/// Execute predictor-corrector scheme for Nordsieck's method
		/// </summary>
		/// <param name="currstate"></param>
		/// <param name="flag"></param>
		/// <param name="f">right parts vector</param>
		/// <param name="opts">current options</param>
		/// <returns>en - current error vector</returns>
		private static NordsieckState PredictorCorrectorScheme(NordsieckState currstate, ref bool flag, Func<double, Vector, Vector> f, Options opts)
		{
			int n = currstate.xn.Length;

			NordsieckState newstate = new NordsieckState();
			var ecurr = currstate.en;
			newstate.en = ecurr.Clone();
			var xcurr = currstate.xn;
			var x0 = currstate.xn;
			var zcurr = (Matrix)currstate.zn.Clone();
			var qcurr = currstate.qn;
			var qmax = currstate.qmax;
			var dt = currstate.dt;
			var t = currstate.tn;
			var z0 = (Matrix)currstate.zn.Clone();

			//Tolerance computation factors
			double Cq = Math.Pow(qcurr + 1, -1.0);
			double tau = 1.0 / (Cq * Factorial(qcurr) * l[qcurr - 1][qcurr]);

			int count = 0;

			double Dq = 0.0, DqUp = 0.0, DqDown = 0.0;
			double delta = 0.0;

			//Scaling factors for the step size changing
			//with new method order q' = q, q + 1, q - 1, respectively
			double rSame, rUp, rDown;

			var xprev = Vector.Zeros(n);
			var gm = Vector.Zeros(n);
			var deltaE = Vector.Zeros(n);
			var M = Matrix.Identity(n, qmax - 1);

			if (opts.SparseJacobian == null)
			{
				Matrix J = opts.Jacobian == null ? NordsieckState.Jacobian(f, xcurr, t + dt) : opts.Jacobian;
				Matrix P = Matrix.Identity(n, n) - J * dt * b[qcurr - 1];

				do
				{
					xprev = xcurr.Clone();
					gm = dt * f(t + dt, xcurr) - z0.CloneColumn(1) - ecurr;
					ecurr = ecurr + P.SolveGE(gm);
					xcurr = x0 + b[qcurr - 1] * ecurr;

					//Row dimension is smaller than zcurr has
					M = ecurr & l[qcurr - 1];
					//So, "expand" the matrix
					var MBig = Matrix.Identity(zcurr.RowDimension, zcurr.ColumnDimension);
					for (int i = 0; i < zcurr.RowDimension; i++)
					{
						for (int j = 0; j < zcurr.ColumnDimension; j++)
						{
							MBig[i, j] = i < M.RowDimension && j < M.ColumnDimension ? M[i, j] : 0.0d;
						}
					}
					zcurr = z0 + MBig;
					Dq = ecurr.ToleranceNorm(opts.RelativeTolerance, opts.AbsoluteTolerance, xprev);
					deltaE = ecurr - currstate.en;
					deltaE *= (1.0 / (qcurr + 2) * l[qcurr - 1][qcurr - 1]);
					DqUp = deltaE.ToleranceNorm(opts.RelativeTolerance, opts.AbsoluteTolerance, xcurr);
					DqDown = zcurr.CloneColumn(qcurr - 1).ToleranceNorm(opts.RelativeTolerance, opts.AbsoluteTolerance, xcurr);
					delta = Dq / (tau / (2 * (qcurr + 2)));
					count++;
				} while (delta > 1.0d && count < opts.NumberOfIterations);
			}
			else
			{
				SparseMatrix J = opts.SparseJacobian;
				SparseMatrix P = SparseMatrix.Identity(n, n) - J * dt * b[qcurr - 1];

				do
				{
					xprev = xcurr.Clone();
					gm = dt * f(t + dt, xcurr) - z0.CloneColumn(1) - ecurr;
					ecurr = ecurr + P.SolveGE(gm);
					xcurr = x0 + b[qcurr - 1] * ecurr;
					//Row dimension is smaller than zcurr has
					M = ecurr & l[qcurr - 1];
					//So, "expand" the matrix
					var MBig = Matrix.Identity(zcurr.RowDimension, zcurr.ColumnDimension);
					for (int i = 0; i < zcurr.RowDimension; i++)
					{
						for (int j = 0; j < zcurr.ColumnDimension; j++)
						{
							MBig[i, j] = i < M.RowDimension && j < M.ColumnDimension ? M[i, j] : 0.0d;
						}
					}
					zcurr = z0 + MBig;
					Dq = ecurr.ToleranceNorm(opts.RelativeTolerance, opts.AbsoluteTolerance, xprev);
					deltaE = ecurr - currstate.en;
					deltaE *= (1.0 / (qcurr + 2) * l[qcurr - 1][qcurr - 1]);
					DqUp = deltaE.ToleranceNorm(opts.RelativeTolerance, opts.AbsoluteTolerance, xcurr);
					DqDown = zcurr.CloneColumn(qcurr - 1).ToleranceNorm(opts.RelativeTolerance, opts.AbsoluteTolerance, xcurr);
					delta = Dq / (tau / (2 * (qcurr + 2)));
					count++;
				} while (delta > 1.0d && count < opts.NumberOfIterations);
			}

			//======================================

			var nsuccess = count < opts.NumberOfIterations ? currstate.nsuccess + 1 : 0;

			if (count < opts.NumberOfIterations)
			{
				flag = false;
				newstate.zn = (Matrix)zcurr.Clone();
				newstate.xn = zcurr.CloneColumn(0);
				newstate.en = ecurr.Clone();
			}
			else
			{
				flag = true;
				newstate.zn = (Matrix)currstate.zn.Clone();
				newstate.xn = currstate.zn.CloneColumn(0);
				newstate.en = currstate.en.Clone();
			}

			//Compute step size scaling factors
			rUp = 0.0;

			if (currstate.qn < currstate.qmax)
			{
				rUp = rUp = 1.0 / 1.4 / (Math.Pow(DqUp, 1.0 / (qcurr + 2)) + 1e-6);
			}

			rSame = 1.0 / 1.2 / (Math.Pow(Dq, 1.0 / (qcurr + 1)) + 1e-6);

			rDown = 0.0;

			if (currstate.qn > 1)
			{
				rDown = 1.0 / 1.3 / (Math.Pow(DqDown, 1.0 / (qcurr)) + 1e-6);
			}

			//======================================
			newstate.nsuccess = nsuccess >= currstate.qn ? 0 : nsuccess;
			//Step size scale operations

			if (rSame >= rUp)
			{
				if (rSame <= rDown && nsuccess >= currstate.qn && currstate.qn > 1)
				{
					newstate.qn = currstate.qn - 1;
					newstate.Dq = DqDown;

					for (int i = 0; i < n; i++)
					{
						for (int j = newstate.qn + 1; j < qmax + 1; j++)
						{
							newstate.zn[i, j] = 0.0;
						}
					}
					nsuccess = 0;
					newstate.rFactor = rDown;
				}
				else
				{
					newstate.qn = currstate.qn;
					newstate.Dq = Dq;
					newstate.rFactor = rSame;
				}
			}
			else
			{
				if (rUp >= rDown)
				{
					if (rUp >= rSame && nsuccess >= currstate.qn && currstate.qn < currstate.qmax)
					{
						newstate.qn = currstate.qn + 1;
						newstate.Dq = DqUp;
						newstate.rFactor = rUp;
						nsuccess = 0;
					}
					else
					{
						newstate.qn = currstate.qn;
						newstate.Dq = Dq;
						newstate.rFactor = rSame;
					}
				}
				else
				{
					if (nsuccess >= currstate.qn && currstate.qn > 1)
					{
						newstate.qn = currstate.qn - 1;
						newstate.Dq = DqDown;

						for (int i = 0; i < n; i++)
						{
							for (int j = newstate.qn + 1; j < qmax + 1; j++)
							{
								newstate.zn[i, j] = 0.0;
							}
						}
						nsuccess = 0;
						newstate.rFactor = rDown;
					}
					else
					{
						newstate.qn = currstate.qn;
						newstate.Dq = Dq;
						newstate.rFactor = rSame;
					}
				}
			}

			newstate.qmax = qmax;
			newstate.dt = dt;
			newstate.tn = t;
			return newstate;
		}
	}
}