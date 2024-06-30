using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPerlinTerrain : MonoBehaviour
{
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    public int xSize = 20;
    public int zSize = 20;
    public float heightMultiplier = 3f;
    public float noiseScale = 0.2f;

    private float time = 0.0f;
    public float timeSpeed = 0.1f;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
    }

    void Update()
    {
        time += timeSpeed;
        CreateShape();
        UpdateMesh();
    }

    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        triangles = new int[xSize * zSize * 6];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * noiseScale, z * noiseScale) * Mathf.PerlinNoise(z * noiseScale, time) * heightMultiplier;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris] = vert;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
