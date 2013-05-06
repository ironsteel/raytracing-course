/************************************************************
	Copyright (C) 2006-2013 by Hristo Lesev
	hristo.lesev@diadraw.com
	for educational purposes only, not for commercial use
************************************************************/
using System;
using RayTracer.Core;
using RayTracer.Math;


namespace RayTracer.BRDFs
{
	/// <summary>
	/// Description of PhongBRDF.
	/// </summary>
	public class PhongBRDF : BRDF {
		
		private double glossy;
		private int numRays;
		
		public PhongBRDF(double _glossy, int _numRays) {
			glossy = 1.0/System.Math.Pow(1.0-_glossy, 3.5)-1.0;
			numRays = _numRays;
			
		}

		public override Color3 eval(RayContext rayContext, Vector3 wi, out double pdf) 
		{
            pdf = 1;
            return new Color3();
		}

		public override bool getSample(RayContext rayContext, double ru, double rv, out Vector3 wi, out double invPdf)
        {
            invPdf = 1;
            wi = new Vector3();
            return false;
        }
		
		public override bool isSingular() 
		{
			return false;
		}

        public override BRDFTypes getType()
        {
            return BRDFTypes.Specular | BRDFTypes.Glossy;
        }
		
	}
}
