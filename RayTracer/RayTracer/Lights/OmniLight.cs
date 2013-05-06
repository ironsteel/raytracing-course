/************************************************************
	Copyright (C) 2006-2013 by Hristo Lesev
	hristo.lesev@diadraw.com
	for educational purposes only, not for commercial use
************************************************************/
using System;
using RayTracer.Core;
using RayTracer.Math;

namespace RayTracer.Lights
{
	/// <summary>
	/// Description of OmniLight.
	/// </summary>
	public class OmniLight : Light {
		
		public Vector3 pos;
		public Color3 color;
		public double power;
		
		public OmniLight() 
		{
			pos = new Vector3();
			color = new Color3();
			power = 1.0;
		}

        public override bool isSingular()
        {
            return true;
        }

        public override LightSample getSample(RayContext rayContext, double ru, double rv)
        {
            return null;
		}
		
		
	}
}
