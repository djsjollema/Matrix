using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectingLines : MonoBehaviour
{
    [SerializeField] VectorLine l;
    [SerializeField] GameObject pointA;
    [SerializeField] GameObject pointB;

    [SerializeField] VectorLine m;
    [SerializeField] GameObject pointC;
    [SerializeField] GameObject pointD;

    [SerializeField] GameObject intersect;

    Vector2 minWorldPoints;
    Vector2 maxWorldPoints;

    void Start()
    {
        minWorldPoints = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxWorldPoints = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        l.lineColor = Color.yellow;
        l.lineThrougTwoPoints(pointA.transform, pointB.transform);
        l.DrawLine(-10, 10);

        m.lineColor = Color.red;
        m.lineThrougTwoPoints(pointC.transform, pointD.transform);
        m.DrawLine(-10, 10);

        intersect.transform.position = l.VectorLineIntersection(m);
    }
}

