using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 SourceVector;

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    float length;
    LineRenderer lineRenderer;

    [SerializeField] GameObject ArrowHead;

    float arrowWidth = 0.3f;
    float arrowHeight = 0.15f;

    void Start()
    {
        
        mesh = new Mesh();
        ArrowHead.GetComponent<MeshFilter>().mesh = mesh;
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        length = SourceVector.magnitude;
        transform.LookAt(SourceVector + SourceVector);
        ArrowHead.transform.position = new Vector3(length, 0, 0);

        SetLine();
        CreateShape();
        UpdateMesh();
    }

    void SetLine()
    {
        lineRenderer.SetPosition(0, new Vector3(0,0,0));
        lineRenderer.SetPosition(1, new Vector3(length, 0));
    }
    void CreateShape()
    {
        vertices = new Vector3[]
        {
            
            new Vector3(0,-arrowHeight,0),
            new Vector3(0, arrowHeight,0),
            new Vector3(arrowWidth + arrowHeight,0),
        };
        triangles = new int[] 
            { 0, 1, 2 };
    }

    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
