using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject linePrefab;
    Line activeLine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineGO = Instantiate(linePrefab);
            activeLine = lineGO.GetComponent<Line>();
        }

        // the user finishes drawing a line
        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        // if the user is still drawing the line
        if (activeLine != null)
        {
            // update the line according to current mouse position
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }

    }
}
