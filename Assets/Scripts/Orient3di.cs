using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orient3di : MonoBehaviour
{
    [SerializeField] GameObject[] Points;

    Color[] Colors = new Color[]{
        new Color(1,0,0),
        new Color(0,1,0),
        new Color(0,0,1),
        new Color(1,1,1)
    };

    Mesh mesh;
    Matrix4x4 matrix;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        for (int i = 0; i < Points.Length; i++)
        {
            setRandomPosition(Points[i]);
            MeshRenderer mr = Points[i].GetComponent<MeshRenderer>();
            mr.material.color = Colors[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mesh.Clear();
            Vector3[] vertices = new Vector3[4];
            int[] triangles = new int[] 
            {
                0,1,2
            };

            matrix = new Matrix4x4();

            for (int i = 0; i < Points.Length; i++)
            {
                
                {
                    setRandomPosition(Points[i]);
                    {
                        vertices[i] = Points[i].transform.position;
                    }
                    
                }
                matrix.SetRow(i, Points[i].transform.position);
            }
            matrix.SetColumn(3, new Vector4(1,1,1,1));
            Debug.Log(matrix.determinant);
            
            mesh.vertices = vertices;
            mesh.triangles = triangles;
        }

    }

    void setRandomPosition(GameObject gameobject)
    {
        float x = Random.Range(-3, 3);
        float y = Random.Range(-3, 3);
        float z = Random.Range(-3, 3);
        gameobject.transform.position = new Vector3(x, y, z);
    }
}
