using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {
    public GameObject WordsManager;
    public GameObject DataManager;
    public GameObject GraphWrapper;
    public List<GameObject> Points;
    public List<GameObject> Lines;

    private void Start()
    {
        GetChildren();
    }

    public void GetChildren()
    {
        Points = new List<GameObject>();
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

    public void TransformToHierarchy(float defaultHeight)
    {
        gameObject.GetComponent<AutoRotation>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        TransformPoints(defaultHeight);
        TransformGraph();
    }

    public void TransformPoints(float defaultHeight)
    {
        foreach (GameObject point in Points)
        {
            iTween.MoveTo(point, iTween.Hash("position", point.GetComponent<Point>().HierarchyPosition - new Vector3(0, 0, defaultHeight), "islocal", true, "easeType", "easeInOutExpo", "delay", 1, "onstart", "DisappearLines", "onstarttarget", gameObject, "oncomplete", "TransformLines", "oncompletetarget", gameObject, "oncompleteparams", defaultHeight));
        }
    }

    public void TransformLines(float defaultHeight)
    {
        foreach (GameObject line in Lines)
        {
            line.GetComponent<LineRenderer>().SetPosition(0, line.GetComponent<Line>().HierarchyStartPosition);
            line.GetComponent<LineRenderer>().SetPosition(1, line.GetComponent<Line>().HierarchyEndPosition);
            line.transform.localPosition = new Vector3(0, 0, -defaultHeight);
        }
        AppearLines();
    }

    public void DisappearLines()
    {
        foreach (GameObject line in Lines)
        {
            line.SetActive(false);
        }
    }

    public void AppearLines()
    {
        foreach (GameObject line in DataManager.GetComponent<DataManager>().linesInSameLayer)
        {
            line.SetActive(true);
        }
    }

    public void TransformGraph()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", 0.045, "y", 0.045, "z", 0.045, "easeType", "easeInOutExpo", "delay", 1));
    }
}
