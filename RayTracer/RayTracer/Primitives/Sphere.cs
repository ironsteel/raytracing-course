/************************************************************
	Copyright (C) 2006-2013 by Hristo Lesev
	hristo.lesev@diadraw.com
	for educational purposes only, not for commercial use
************************************************************/
using System;
using RayTracer.Math;
using RayTracer.Core;

namespace RayTracer.Primitives
{
	/// <summary>
	/// Description of Sphere.
	/// </summary>
	public class Sphere : GeomPrimitive {
		
		public Vector3 center;
		public double radius;
		
		public Sphere() {
			center = new Vector3();
			radius = 1;
		}

        public override BoundingBox GetBoundingBox()
        {
            var min = new Vector3(center.x - radius, center.y - radius, center.z - radius);
            var max = new Vector3(center.x + radius, center.y + radius, center.z + radius);
            return new BoundingBox(min, max);
        }
		
		public override bool intersect( Ray ray, IntersectionData hitData ) 
        {
			return true;
		}
		
	}
}
