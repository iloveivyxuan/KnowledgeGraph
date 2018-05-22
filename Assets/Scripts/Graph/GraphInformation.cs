using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphInformation : MonoBehaviour {
    public List<GameObject> Points;
    public List<GameObject> Lines;

    void Start () {
        GetPointsAndLines();
    }

    public void GetPointsAndLines()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Point>())
            {
                Points.Add(child.gameObject);
            }
            if (child.gameObject.GetComponent<Line>())
            {
                Lines.Add(child.gameObject);
            }
        }
    }

    public void AppearlabelToPoints()
    {
        foreach (GameObject point in Points)
        {
            point.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
