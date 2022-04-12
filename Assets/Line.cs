using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    List<Vector2> points;

    public void UpdateLine(Vector2 mousePos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }
        // **check** if the mouse has moved enough for us to insert new point
        // points.last() is the same as points[points.Count - 1]
        if (Vector2.Distance(points.Last(), mousePos) > .1f)
        {
            SetPoint(mousePos);
        }



        // if it has, insert point at mouse position

    }
    void SetPoint(Vector2 point)
    {
        // point is mouse position
        // add point to the points list
        points.Add(point);

        // add point to the line renderer
        // 1. set the num of points on the line renderer = length of points list
        lineRenderer.positionCount = points.Count;
        // 2. add the point to the last index
        lineRenderer.SetPosition(points.Count - 1, point);

        // make sure we have at least 2 points to make a line
        if (points.Count > 1)
        {
            edgeCollider.points = points.ToArray();
        }



    }
}
