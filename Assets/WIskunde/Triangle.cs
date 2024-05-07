using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    
    [SerializeField] Transform[] points = new Transform[3];
    [SerializeField] MeshRenderer mr;

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;

    float[,] matrix3x3;
    float determinant;

    void Start()
    {

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        createShape();
        updateMesh();
        //mr.material.
    }

    void Update()
    {
        matrix3x3 = new float[,]
        {
            {points[0].position.x,points[0].position.y,1},
            {points[1].position.x,points[1].position.y,1},
            {points[2].position.x,points[2].position.y,1}
        };

        determinant = SDMath.determinant(matrix3x3);

        createShape();
        updateMesh();

        if (determinant < 0)
        {
            mr.material.color = new Vector4(1, 1, 0, 0.4f);
        }
        else
        {
            mr.material.color = new Vector4(0, 1, 1, 0.4f);
        }
    }

    void createShape()
    {
        vertices = new Vector3[]
        {
            points[0].position,
            points[1].position,
            points[2].position
        };

        triangles = new int[]
        {
            0,1,2
        };
    }

    void updateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        
    }
}
