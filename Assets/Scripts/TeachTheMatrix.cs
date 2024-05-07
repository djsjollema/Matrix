using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeachTheMatrix : MonoBehaviour
{
    [SerializeField] Transform A;
    [SerializeField] Transform B;
    [SerializeField] Transform C;

    Matrix4x4 matrix;
    Vector4 a;
    Vector4 b;
    Vector4 c;
    Vector4 d;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float[,] exampleMatrix = new float[,] 
        { 
            { A.position.x, A.position.y, 1 }, 
            { B.position.x, B.position.y, 1 }, 
            { C.position.x, C.position.y, 1 } 
        };
        float det = CalculateDeterminant(exampleMatrix);
        //Debug.Log("Determinant of the matrix: " + det);
        //Debug.Log("waarde:" + exampleMatrix[1,1]);
    }

    public float CalculateDeterminant(float[,] matrix)
    {
        float determinant = 0;

        determinant = matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                    - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                    + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);

        return determinant;
    }
}
