using System.Collections.Generic;
using UnityEngine;

public class WordsManager : MonoBehaviour {
    public GameObject InfoGraph;
    public List<string> Words;
    public List<GameObject> Points;
    public List<string> Types;
    public float GraphTransitionHeight;

    private void Start()
    {
        Words = new List<string>(new string[] { "Gillenormand", "Magnon", "Mlle_Baptistine" });
        Points = FindAllPointByLabels(Words);
        Types = GetLayers(Points);
        string defaultLayerType = DefaultLayerType(Points, Types);
        GraphTransitionHeight = DefaultLayerHeight(Points, defaultLayerType);
    }

    public float GetGraphTransitionHeight(List<string> words)
    {
        List<GameObject> points = FindAllPointByLabels(words);
        List<string> types = GetLayers(points);
        string defaultLayer = DefaultLayerType(points, types);
        float defaultLayerHeight = DefaultLayerHeight(points, defaultLayer);
        return defaultLayerHeight;
    }

    public List<GameObject> FindAllPointByLabels(List<string> words)
    {
        List<GameObject> selectedPoints = new List<GameObject>();
        foreach (string word in words)
        {
            selectedPoints.Add(FindByLabel(word));
        }
        return selectedPoints;
    }

    public GameObject FindByLabel(string label)
    {
        List<GameObject> points = InfoGraph.GetComponent<Transition>().Points;
        foreach (GameObject point in points)
        {
            if (point.GetComponent<Point>().Label == label)
            {
                return point;
            }
        }
        return null;
    }

    private List<string> GetLayers(List<GameObject> points)
    {
        List<string> types = new List<string>();
        foreach (GameObject point in points)
        {
            if (!types.Contains(point.GetComponent<Point>().Type))
            {
                types.Add(point.GetComponent<Point>().Type);
            }
        }
        return types;
    }

    private int CountWordsOnLayer(List<GameObject> points, string type)
    {
        int size = 0;
        foreach (GameObject point in points)
        {
            if (point.GetComponent<Point>().Type == type)
            {
                size += 1;
            }
        }
        return size;
    }

    public string DefaultLayerType(List<GameObject> points, List<string> types)
    {
        int maxSize = 0;
        string maxType = "";
        foreach (string type in types)
        {
            if (CountWordsOnLayer(points, type) > maxSize)
            {
                maxSize = CountWordsOnLayer(points, type);
                maxType = type;
            }
        }
        return maxType;
    }

    public float DefaultLayerHeight(List<GameObject> points, string type)
    {
        foreach (GameObject point in points)
        {
            if (point.GetComponent<Point>().Type == type)
            {
                return point.GetComponent<Point>().HierarchyPosition.z;
            }
        }
        return 0f;
    }
}
