using System;
using RayTracer.Core;
using RayTracer.Math;

namespace RayTracer.Primitives
{
	public class Torus : GeomPrimitive
	{
		public double innerRadius = 0;
		public double outerRadius = 0;

		public Torus ()
		{
		}

		#region implemented abstract members of GeomPrimitive

		public override bool intersect (Ray ray, IntersectionData hitData)
		{
			double dirDot = ray.dir * ray.dir;
			double posDotDir = ray.p * ray.dir;
			double posDot = ray.p * ray.p;
			double outerSquared = outerRadius * outerRadius;
			double innerSquared = innerRadius * innerRadius;

			double a4 = dirDot * dirDot;
			double a3 = 4 * dirDot * posDotDir;
			double val = (posDot - innerSquared - outerSquared);
			double a2 = 4 * posDotDir * posDotDir + 2 * dirDot * val + 4 * outerSquared * ray.dir.z * ray.dir.z;
			double a1 = 4 * posDotDir * val + 8 * outerSquared * ray.p.z * ray.dir.z;
			double a0 = val * val + 4 * outerSquared * ray.p.z * ray.p.z - 4 * outerSquared * innerSquared;

			double[] coef =
			new double[] {
				a4,
				a3,
				a2,
				a1,
				a0
			};


			double[] roots = QuarticSolver.solve (coef);
			if (roots.Length == 0) 
				return false;

			double t = roots[0];
			for (int i = 1; i < roots.Length; i++) {
				if( roots[i] < t) {
					t = roots[i];
				}
			}
		
			if (MathUtils.IsZero(t))
				return false;

			hitData.hitT = t;
			hitData.hitPos = ray.p + (hitData.hitT * ray.dir);
			hitData.hitPrimitive = this;
			hitData.hitNormal = getNormal (hitData.hitPos);
			hitData.hitNormal.normalize ();

			return true;

		}

		private Vector3 getNormal(Vector3 point) 
		{
			double temp = point * point - innerRadius * innerRadius - outerRadius * outerRadius;
			double x = 4 * point.x * temp;
			double y = 4 * point.y * temp;
			double z = 4 * point.z * temp + 8 * outerRadius * outerRadius * point.x;
			return new Vector3 (x, y, z);
		}

		public override RayTracer.Math.BoundingBox GetBoundingBox ()
		{
			double r1 = innerRadius;
			double r2 = outerRadius + innerRadius;
			return new BoundingBox(new Vector3(-r2, -r1, -r2), new Vector3(2.0 * r2, 2.0 * r1, 2.0 * r2));
		}

		#endregion
	}
}

