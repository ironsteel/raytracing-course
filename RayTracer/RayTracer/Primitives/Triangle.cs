/************************************************************
	Copyright (C) 2006-2013 by Hristo Lesev
	hristo.lesev@diadraw.com
	for educational purposes only, not for commercial use
************************************************************/
using System;
using RayTracer.Core;
using RayTracer.Math;

namespace RayTracer.Primitives
{
	/// <summary>
	/// Description of Triangle.
	/// </summary>
	public class Triangle : GeomPrimitive {
		
		public Vector3[] v;

		public Vector3[] tc;

		public Vector3[] vn; 

		public int shaderID;

		public Triangle() 
		{
			v = new Vector3[3];
			tc = new Vector3[3];
			vn = new Vector3[3];
			shaderID = 0;
		}

        public override BoundingBox GetBoundingBox()
        {
            var minX = v[0].x < v[1].x ? v[0].x : v[1].x;
            minX = minX < v[2].x ? minX : v[2].x;

            var minY = v[0].y < v[1].y ? v[0].y : v[1].y;
            minY = minY < v[2].y ? minY : v[2].y;

            var minZ = v[0].z < v[1].z ? v[0].z : v[1].z;
            minZ = minZ < v[2].z ? minZ : v[2].z;
            //--------------------------------------------
            var maxX = v[0].x > v[1].x ? v[0].x : v[1].x;
            maxX = maxX > v[2].x ? maxX : v[2].x;

            var maxY = v[0].y > v[1].y ? v[0].y : v[1].y;
            maxY = maxY > v[2].y ? maxY : v[2].y;

            var maxZ = v[0].z > v[1].z ? v[0].z : v[1].z;
            maxZ = maxZ > v[2].z ? maxZ : v[2].z;

            if ((minX - maxX) < 0.001)
            {
                minX -= 0.1;
                maxX += 0.1;
            }

            if ((minY - maxY) < 0.001)
            {
                minY -= 0.1;
                maxY += 0.1;
            }

            if ((minZ - maxZ) < 0.001)
            {
                minZ -= 0.1;
                maxZ += 0.1;
            }

            var min = new Vector3(minX, minY, minZ);
            var max = new Vector3(maxX, maxY, maxZ);

            return new BoundingBox(min, max);
        }
		
		public override bool intersect( Ray ray, IntersectionData hitData ) 
		{
            return false;
		}
		
	}
}
