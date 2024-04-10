using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

using static Unity.Mathematics.math;

namespace ProceduralMeshes.Generators
{
    public struct PointyHexagonGrid : IMeshGenerator
    {
        public int VertexCount => 7 * Resolution * Resolution;

        public int IndexCount => 18 * Resolution * Resolution;

        public int JobLength => Resolution;

        public Bounds Bounds => new Bounds(Vector3.zero, new Vector3(1f, 0f, 1f));

        public int Resolution { get; set; }

        public void Execute<S>(int z, S streams) where S : struct, IMeshStreams
        {
            int vi = 7 * Resolution * z, ti = 6 * Resolution * z;

            for (int x = 0; x < Resolution; x++, vi += 4, ti += 2)
            {
                
            }      
        }
    }
}