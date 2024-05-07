using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLine : MonoBehaviour
{
    public Vector3 supportVector;
    public Vector3 directionVector;

    public Color lineColor;
    LineRenderer lineRenderer;


    // Update is called once per frame
    public void DrawLine(float n_min, float n_max)
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.startColor = lineColor;

        lineRenderer.SetPosition(0, this.supportVector + n_min*this.directionVector);
        lineRenderer.SetPosition(1, this.supportVector + n_max * this.directionVector);
    }

    public void lineThrougTwoPoints(Transform P, Transform Q)
    {
        this.supportVector = P.position;
        this.directionVector = (Q.position - P.position).normalized;
        Debug.Log("SupportVector: " + supportVector);
        Debug.Log("directionVector: " + directionVector);
    }

    public float getNbyX(float x_in)
    {
        return (x_in - this.supportVector.x) / directionVector.x; 
    }

    public float getNbyY(float y_in)
    {
        return (y_in - this.supportVector.y) / directionVector.y;
    }

    public Vector3 VectorLineIntersection(VectorLine m)
    {

        float s, t, detA, detAs, detAt;
        float[,] A;
        float[,] As;
        float[,] At;

      
        A = new float[,]
        {
            {this.directionVector.x, -1 * m.directionVector.x},
            {this.directionVector.y, -1 * m.directionVector.y}
        };


        At = new float[,]
        {
            { m.supportVector.x - this.supportVector.x, -m.directionVector.x},
            { m.supportVector.y - this.supportVector.y, - m.directionVector.y}
        };
        

        As = new float[,]
        {
            { m.supportVector.x, m.directionVector.x - this.directionVector.x },
            { m.supportVector.y , m.directionVector.y - this.directionVector.y }
        };
              

        detA = (A[0, 0] * A[1, 1]) - (A[1, 0] * A[0, 1]);
        detAt = (At[0, 0] * At[1, 1]) - (At[1, 0] * At[0, 1]);
        detAs = (As[0, 0] * As[1, 1]) - (As[1, 0] * As[0, 1]);
        


        t = detAt / detA;
        s = detAt / detA;
        

        Vector3 intersectT = this.supportVector + (t * this.directionVector);
        Vector3 intersectS = this.supportVector + (s * this.directionVector);

        Debug.Log("A:" +A[0, 0] + " " + A[1, 0] + " " + A[0, 1] + " " + A[1, 1]);
        Debug.Log("At:" + At[0, 0] + " " + At[1, 0] + " " + At[0, 1] + " " + At[1, 1]);
        Debug.Log("determinant A:" + detA + " determinant At:" + detAt);
        //Debug.Log("parameter s:" + s + " parameter t:" + t);
        //Debug.Log(intersectS + " " + intersectT);

        return intersectT;
    }
}
