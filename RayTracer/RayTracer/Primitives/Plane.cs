using System;
using RayTracer.Core;
using RayTracer.Math;

namespace RayTracer.Primitives
{
	public class Plane : GeomPrimitive
	{

		public Vector3 point;
		public Vector3 normal;

		public Plane ()
		{
			point = new Vector3 (0, 0, 0);
			normal = new Vector3 (0, 0, 0);
		}


		#region implemented abstract members of GeomPrimitive
		
		public override bool intersect (Ray ray, IntersectionData hitData)
		{
			double denom = ray.dir * normal;
			if (MathUtils.IsZero(denom))
				return false;

			double nom = (point - ray.p) * normal;
			double t = nom / denom;

			hitData.hasIntersection = true;
			hitData.hitT = t;
			hitData.hitPos = ray.p + (hitData.hitT * ray.dir);
			hitData.hitPrimitive = this;
			hitData.hitNormal = normal;

			return true;

		}
		
		public override RayTracer.Math.BoundingBox GetBoundingBox ()
		{
			return new BoundingBox(new Vector3(), new Vector3());
		}
		
		#endregion

	}
}

