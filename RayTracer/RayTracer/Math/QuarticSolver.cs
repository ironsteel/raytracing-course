using System;
using RayTracer.Math;
using System.Collections;
using System.Collections.Generic;


namespace RayTracer
{
	public class QuarticSolver
	{
		const int NO_EINGEN_VECTORS = 0;

		private QuarticSolver ()
		{
		}

		private static double[] toMonic(double[] coef) 
		{
			double[] monicCoef = new double[4]; 
			if (!MathUtils.IsZero (coef [0])) 
			{
				for (int i = 1; i < coef.Length; i++) 
				{
					monicCoef [i - 1] = coef [i] / coef [0];
				}
			} 
			else 
			{
				for (int i = 1; i < coef.Length; i++) 
				{
					monicCoef [i - 1] = coef [i];
				}
			}
			return monicCoef;
		}

		public static double[] solve(double[] coef)
		{
			List<double> roots = new List<double>();
			double[] monic = toMonic (coef);
			double[,]  companionMatrix = new double[4,4];

			for(int i = 0; i < 4; i++) {
				companionMatrix[i,3] = - monic[3 - i]; 
			}

			for (int i = 1; i < 4; i++) {
				companionMatrix[i,i - 1] = 1;
			}


			double[] eigenValuesReal;
			double[] eigenValuesImagenary;

			// Left and right eigen vectors are not needed
			double[,] vl;
			double[,] vr;

			if (!alglib.rmatrixevd (companionMatrix, companionMatrix.GetLength (0), NO_EINGEN_VECTORS, out eigenValuesReal, out eigenValuesImagenary, out vl, out vr)) {
				return new double[0];
			}
			
			for (int i = 0; i < eigenValuesReal.Length; i++) {
				if(MathUtils.IsZero(eigenValuesImagenary[i])) {
					roots.Add(eigenValuesReal[i]);
				}
			}
			return roots.ToArray();
		}
	}
}

