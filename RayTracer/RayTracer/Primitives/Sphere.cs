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
			ray.p = ray.p - center;
			double a = ray.dir * ray.dir;
			double b = 2 * (ray.dir * ray.p);
			double c = (ray.p * ray.p) - (radius * radius);
			ray.p = ray.p + center;

			double discriminant = b * b - 4 * a * c;
			if (discriminant < 0)
				return false;
			
			discriminant = System.Math.Sqrt (discriminant);
			
			double t1 = (-b - discriminant) / (2 * a);
			double t2 = (-b + discriminant) / (2 * a);
			
			hitData.hitT = System.Math.Min(t1, t2);
			hitData.hasIntersection = true;
			Vector3 hitPoint = ray.p + (hitData.hitT * ray.dir);
			hitData.hitPos = hitPoint;
			hitData.hitPrimitive = this;
			hitData.hitNormal = (hitData.hitPos - center);
			hitData.hitNormal.normalize();

			double u = (System.Math.PI + System.Math.Atan2(hitPoint.z - center.z, hitPoint.x - center.x)) / (System.Math.PI * 2);
			double v = 1.0 - ((System.Math.PI / 2) + System.Math.Asin((hitPoint.y - center.y) / radius)) / System.Math.PI;
			
			hitData.textureUVW = new Vector3(u, v, 0);
			
			return true;
		}
		
	}
}
