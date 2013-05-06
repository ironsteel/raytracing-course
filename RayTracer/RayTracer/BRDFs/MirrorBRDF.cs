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
	/// Description of MirrorBRDF.
	/// </summary>
	public class MirrorBRDF : BRDF {
		
		public MirrorBRDF() {
		}

        public override bool getSample(RayContext rayContext, double ru, double rv, out Vector3 wi, out double invPdf)
        {
            invPdf = 1;
            wi = new Vector3();
            return false;
        }

		public override bool isSingular() {
			return true;
		}

        public override BRDFTypes getType()
        {
            return BRDFTypes.Specular | BRDFTypes.Perfect;
        }
		
	}
}
