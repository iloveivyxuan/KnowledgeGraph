using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject WordsManager;
    public GameObject DataManager;
    public GameObject GraphWrapper;
    public GameObject Menu;
    public GameObject LayerToInstantiate;

    public void TransformToHierarchy(float defaultHeight)
    {
        gameObject.GetComponent<AutoRotation>().isRotating = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        TransformPoints(defaultHeight);
        ScaleTo(0.045f);
        AppearLayers(defaultHeight);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    public void TransformToSpherical()
    {
        gameObject.GetComponent<AutoRotation>().isRotating = true;
        gameObject.GetComponent<SphereCollider>().enabled = true;

        foreach (GameObject point in GetComponent<GraphInformation>().Points)
        {
            iTween.MoveTo(point, iTween.Hash("position", point.GetComponent<Point>().SphericalPosition, "islocal", true, "easeType", "easeInOutExpo", "delay", 1));
            foreach (GameObject line in GetComponent<GraphInformation>().Lines)
            {
                line.GetComponent<LineRenderer>().SetPosition(0, line.GetComponent<Line>().SphericalStartPosition);
                line.GetComponent<LineRenderer>().SetPosition(1, line.GetComponent<Line>().SphericalEndPosition);
                line.transform.localPosition = new Vector3(0, 0, 0);
                line.SetActive(true);
            }
        }
        ScaleTo(0.006f);
        transform.localPosition = new Vector3(0, 0.15f, 0);
    }

    private void TransformPoints(float defaultHeight)
    {
        foreach (GameObject point in GetComponent<GraphInformation>().Points)
        {
            iTween.MoveTo(point, iTween.Hash("position", point.GetComponent<Point>().HierarchyPosition - new Vector3(0, 0, defaultHeight), "islocal", true, "easeType", "easeInOutExpo", "delay", 1, "onstart", "DisappearLines", "onstarttarget", gameObject, "oncomplete", "TransformLines", "oncompletetarget", gameObject, "oncompleteparams", defaultHeight));
        }
    }

    private void TransformLines(float defaultHeight)
    {
        foreach (GameObject line in GetComponent<GraphInformation>().Lines)
        {
            line.GetComponent<LineRenderer>().SetPosition(0, line.GetComponent<Line>().HierarchyStartPosition);
            line.GetComponent<LineRenderer>().SetPosition(1, line.GetComponent<Line>().HierarchyEndPosition);
            line.transform.localScale = new Vector3(1, 1, 1);
            line.transform.localPosition = new Vector3(0, 0, -defaultHeight);
        }
        AppearLines();
    }

    private void DisappearLines()
    {
        foreach (GameObject line in GetComponent<GraphInformation>().Lines)
        {
            line.SetActive(false);
        }
    }

    private void AppearLines()
    {
        foreach (GameObject line in DataManager.GetComponent<DataManager>().linesInSameLayer)
        {
            line.SetActive(true);
        }
    }

    public void ScaleTo(float number)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", number, "y", number, "z", number, "easeType", "easeInOutExpo", "delay", 0));
    }

    public void MoveToCenter()
    {
        iTween.MoveTo(gameObject, iTween.Hash("x", Menu.transform.position.x / 1.5f, "y", Menu.transform.position.y / 1.5f, "z", Menu.transform.position.z / 1.5f));
    }

    private void AppearLayers(float defaultHeight)
    {
        GameObject layerTop = Instantiate(LayerToInstantiate, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject layerBottom = Instantiate(LayerToInstantiate, new Vector3(0, 0, 0), Quaternion.identity);
        layerTop.transform.parent = transform;
        layerBottom.transform.parent = transform;
        layerTop.transform.localPosition = new Vector3(0, 0, defaultHeight + 9f);
        layerBottom.transform.localPosition = new Vector3(0, 0, defaultHeight - 9f);
        layerTop.transform.localScale = new Vector3(50, 0, 50);
        layerBottom.transform.localScale = new Vector3(50, 0, 50);
    }
}