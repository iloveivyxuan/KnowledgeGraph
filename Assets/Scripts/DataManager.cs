using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{

    public GameObject infoGraph;
    public GameObject pointToInstantiate;
    public GameObject edgeToInstantiate;

    private string gameDataFileName = "result_hierarchy.json";

    void Awake()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        string dataAsString = File.ReadAllText(filePath);
        JSONObject dataAsJson = new JSONObject(dataAsString);
        JSONObject nodes = dataAsJson["nodes"];
        JSONObject edges = dataAsJson["edges"];

        JSONObject pointPositions = new JSONObject(JSONObject.Type.OBJECT);

        foreach (JSONObject node in nodes.list)
        {
            string nodeToString = node.Print();
            InfoPoint infoPoint;
            infoPoint = InfoPoint.CreateFromJSON(nodeToString);
            GameObject pointObject = Instantiate(pointToInstantiate, infoPoint.position, Quaternion.identity);
            pointObject.transform.parent = infoGraph.transform;
            // pointObject.transform.GetChild(0).GetComponent<TextMesh>().text = infoPoint.label;
            // pointObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            pointPositions[infoPoint.id] = node["position"];
            // pointObject.GetComponent<NodeID>().id = infoPoint.id;
        }

        foreach (JSONObject edge in edges.list)
        {
            string edgeToString = edge.Print();
            InfoEdge infoEdge;
            infoEdge = InfoEdge.CreateFromJSON(edgeToString);

            JSONObject sourcePosition = pointPositions[infoEdge.source];
            JSONObject targetPosition = pointPositions[infoEdge.target];
            Vector3 startPosition = new Vector3(x: sourcePosition["x"].f, y: sourcePosition["y"].f, z: sourcePosition["z"].f);
            Vector3 endPosition = new Vector3(x: targetPosition["x"].f, y: targetPosition["y"].f, z: targetPosition["z"].f);

            LineRenderer lineRenderer = edgeToInstantiate.GetComponent<LineRenderer>();
            // lineRenderer.useWorldSpace = false;
            // edgeToInstantiate.transform.position = startPosition;
            // edgeToInstantiate.transform.localScale = endPosition;

            lineRenderer.SetPosition(0, startPosition);
            lineRenderer.SetPosition(1, endPosition);
            // var edgeLength = lineRenderer.wi
            // var edgeLength = edgeToInstantiate.transform.localScale;
            // edgeLength.y = (endPosition - startPosition).magnitude;
            // edgeToInstantiate.transform.localScale = edgeLength;

            // Vector3 edgePosition = (endPosition - startPosition) / 2.0f + startPosition;
            // Quaternion edgeRotation = Quaternion.FromToRotation(Vector3.up, endPosition - startPosition);
            GameObject edgeObject = Instantiate(edgeToInstantiate, Vector3.zero, Quaternion.identity);
            edgeObject.transform.parent = infoGraph.transform;

            // edgeObject.transform.position = startPosition;
            // edgeObject.GetComponent<LineRenderer>().SetPosition(0, Vector3.zero);
            // edgeObject.GetComponent<LineRenderer>().SetPosition(1, endPosition - startPosition);
            // edgeObject.GetComponent<LineRenderer>().SetPosition(0, startPosition);
            // edgeObject.GetComponent<LineRenderer>().SetPosition(1, endPosition);
            // edgeObject.transform.SetParent(infoGraph.transform);
        }
    }
}