using ProceduralMeshes;
using ProceduralMeshes.Generators;
using ProceduralMeshes.Streams;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralMesh : MonoBehaviour
{
    static MeshJobScheduleDelegate[] jobs =
    {
        MeshJob<SquareGrid, SingleStream>.ScheduleParallel,
        MeshJob<SharedSquareGrid, SingleStream>.ScheduleParallel,
        MeshJob<SharedTriangleGrid, SingleStream>.ScheduleParallel,
        MeshJob<PointyHexagonGrid, SingleStream>.ScheduleParallel,
        MeshJob<FlatHexagonGrid, SingleStream>.ScheduleParallel
    };

    public enum MeshType { SquareGrid, SharedSquareGrid, SharedTriangleGrid, PointyHexagonGrid, FlatHexagonGrid }

    [SerializeField]
    MeshType meshType;

    Mesh mesh;

    [SerializeField, Range(1, 50)]
    int resolution = 1;

    private void Awake()
    {
        mesh = new Mesh() { name = "Procedural Mesh" };
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void OnValidate()
    {
        enabled = true;
    }

    private void Update()
    {
        GenerateMesh();
        enabled = false;
    }

    void GenerateMesh()
    {
        Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(1);
        Mesh.MeshData meshData = meshDataArray[0];

        jobs[(int)meshType](mesh, meshData, resolution, default).Complete();

        Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);
    }
}
