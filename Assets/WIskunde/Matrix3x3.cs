using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix3x3
{
    public float[,] matrix;

    public Matrix3x3(float[,] matrix)
    {
        this.matrix = matrix;
    }

    public float determinant()
    {
        float determinant = 0;

        determinant = this.matrix[0, 0] * (this.matrix[1, 1] * this.matrix[2, 2] - this.matrix[1, 2] * this.matrix[2, 1])
                    - this.matrix[0, 1] * (this.matrix[1, 0] * this.matrix[2, 2] - this.matrix[1, 2] * this.matrix[2, 0])
                    + this.matrix[0, 2] * (this.matrix[1, 0] * this.matrix[2, 1] - this.matrix[1, 1] * this.matrix[2, 0]);

        return determinant;
    }
}
