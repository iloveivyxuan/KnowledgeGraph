using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    public GameObject infoGraph;
    public GameObject pointToInstantiate;
    public GameObject edgeToInstantiate;

    public string SphericalDataFileName;
    public string HierarchyDataFileName;

    public List<GameObject> Points;

    public List<GameObject> LinesCrossLayers;
    public List<GameObject> linesInSameLayer;

    [Header("Set Graph Initiation status")]
    [SerializeField]
    public float GraphScale;
    public Vector3 GraphPosition;
    public Vector3 GraphRotation;

    private JSONObject sphericalData;
    private JSONObject hierarchyData;

    private JSONObject sphericalPointPositions;
    private JSONObject hierarchyPointPositions;

    public void GetJsonData()
    {
        string sphericalFilePath = Path.Combine(Application.streamingAssetsPath, SphericalDataFileName);
        string hierarchyFilePath = Path.Combine(Application.streamingAssetsPath, HierarchyDataFileName);
        string sphericalDataAsString = File.ReadAllText(sphericalFilePath);
        string hierarchyDataAsString = File.ReadAllText(hierarchyFilePath);
        sphericalData = new JSONObject(sphericalDataAsString);
        hierarchyData = new JSONObject(hierarchyDataAsString);
    }

    public void CreatePoint(JSONObject sphericalNode, JSONObject hierarchyNode)
    {
        InfoPoint sphericalInfoPoint = InfoPoint.CreateFromJSON(sphericalNode.Print());
        InfoPoint hierarchyInfoPoint = InfoPoint.CreateFromJSON(hierarchyNode.Print());
        GameObject pointObject = Instantiate(pointToInstantiate, sphericalInfoPoint.position, Quaternion.identity);
        Points.Add(pointObject);
        pointObject.transform.parent = infoGraph.transform;

        pointObject.GetComponent<Point>().Id = sphericalInfoPoint.id;
        pointObject.GetComponent<Point>().Label = sphericalInfoPoint.label;
        pointObject.GetComponent<Point>().Type = sphericalInfoPoint.type;
        pointObject.GetComponent<Point>().SphericalPosition = sphericalInfoPoint.position;
        pointObject.GetComponent<Point>().HierarchyPosition = hierarchyInfoPoint.position;
        sphericalPointPositions[sphericalInfoPoint.id] = sphericalNode["position"];
        hierarchyPointPositions[hierarchyInfoPoint.id] = hierarchyNode["position"];
    }

    public void CreateLine(JSONObject sphericalEdge, JSONObject hierarchyEdge)
    {
        InfoEdge sphericalInfoEdge = InfoEdge.CreateFromJSON(sphericalEdge.Print());
        InfoEdge hierarchyInfoEdge = InfoEdge.CreateFromJSON(hierarchyEdge.Print());

        JSONObject sphericalSourcePosition = sphericalPointPositions[sphericalInfoEdge.source];
        JSONObject sphericalTargetPosition = sphericalPointPositions[sphericalInfoEdge.target];
        JSONObject hierarchySourcePosition = hierarchyPointPositions[hierarchyInfoEdge.source];
        JSONObject hierarchyTargetPosition = hierarchyPointPositions[hierarchyInfoEdge.target];
        Vector3 sphericalStartPosition = new Vector3(x: sphericalSourcePosition["x"].f, y: sphericalSourcePosition["y"].f, z: sphericalSourcePosition["z"].f);
        Vector3 sphericalEndPosition = new Vector3(x: sphericalTargetPosition["x"].f, y: sphericalTargetPosition["y"].f, z: sphericalTargetPosition["z"].f);
        Vector3 hierarchyStartPosition = new Vector3(x: hierarchySourcePosition["x"].f, y: hierarchySourcePosition["y"].f, z: hierarchySourcePosition["z"].f);
        Vector3 hierarchyEndPosition = new Vector3(x: hierarchyTargetPosition["x"].f, y: hierarchyTargetPosition["y"].f, z: hierarchyTargetPosition["z"].f);

        LineRenderer lineRenderer = edgeToInstantiate.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, sphericalStartPosition);
        lineRenderer.SetPosition(1, sphericalEndPosition);

        GameObject edgeObject = Instantiate(edgeToInstantiate, Vector3.zero, Quaternion.identity);
        edgeObject.transform.parent = infoGraph.transform;

        if (hierarchyStartPosition.z != hierarchyEndPosition.z)
        {
            LinesCrossLayers.Add(edgeObject);
        }
        else
        {
            linesInSameLayer.Add(edgeObject);
        }

        foreach (GameObject point in Points)
        {
            if (point.GetComponent<Point>().Id == sphericalInfoEdge.source || point.GetComponent<Point>().Id == sphericalInfoEdge.target)
            {
                point.GetComponent<Point>().RelatedLines.Add(edgeObject);
            }
        }

        edgeObject.GetComponent<Line>().SphericalStartPosition = sphericalStartPosition;
        edgeObject.GetComponent<Line>().SphericalEndPosition = sphericalEndPosition;
        edgeObject.GetComponent<Line>().HierarchyStartPosition = hierarchyStartPosition;
        edgeObject.GetComponent<Line>().HierarchyEndPosition = hierarchyEndPosition;
    }

    void Awake()
    {
        GetJsonData();
        JSONObject sphericalNodes = sphericalData["nodes"];
        JSONObject hierarchyNodes = hierarchyData["nodes"];
        JSONObject sphericalEdges = sphericalData["edges"];
        JSONObject hierarchyEdges = hierarchyData["edges"];
        sphericalPointPositions = new JSONObject(JSONObject.Type.OBJECT);
        hierarchyPointPositions = new JSONObject(JSONObject.Type.OBJECT);

        for (int i = 0; i < sphericalData["nodes"].Count; i++)
        {
            CreatePoint(sphericalNodes[i], hierarchyNodes[i]);
        }

        for (int i = 0; i < sphericalEdges.Count; i++)
        {
            CreateLine(sphericalEdges[i], hierarchyEdges[i]);
        } 

        InitialGraph();
    }


    private void InitialGraph()
    {
        infoGraph.transform.localScale = new Vector3(1, 1, 1) * GraphScale;
        infoGraph.transform.position = GraphPosition;
        infoGraph.transform.Rotate(GraphRotation);
    }
}