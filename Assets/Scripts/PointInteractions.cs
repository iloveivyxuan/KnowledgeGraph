using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class PointInteractions : MonoBehaviour, IFocusable {

    public Color NormalColor;
    public Color HighlightColor;
    private Renderer pointRenderer;
    private Material pointMaterialInstance;
    private bool canRotate;
    //private Vector3 initialRotation;
    private Vector3 updateRotation;
    private GameObject point;
    private GameObject label;

    private void Awake()
    {
        point = transform.GetChild(0).gameObject;
        label = transform.GetChild(1).gameObject;
        pointRenderer = point.GetComponent<Renderer>();
        pointMaterialInstance = pointRenderer.material;
    }

    // 如果 MonoBehaviour 已启用，则在每一帧都调用 Update
    private void Update()
    {
        if (canRotate)
        {
            updateRotation = Vector3.zero;
            updateRotation.x = 1;
            updateRotation.y = 2;
            updateRotation.z = 3;
            point.transform.localRotation *= Quaternion.Euler(updateRotation);
        }
    }

    // 当 MonoBehaviour 将被销毁时调用此函数
    private void OnDestroy()
    {
        Destroy(pointMaterialInstance);
    }

    public void OnFocusEnter()
    {
        StartRotation();
        pointMaterialInstance.color = HighlightColor;
        foreach (GameObject line in gameObject.GetComponent<Point>().RelatedLines)
        {
            line.SetActive(true);
        }
    }

    public void OnFocusExit()
    {
        StopRotation();
        pointMaterialInstance.color = NormalColor;
        foreach (GameObject line in gameObject.GetComponent<Point>().RelatedLines)
        {
            if (!line.GetComponent<Line>().IsInSameLayer())
            {
                line.SetActive(false);
            }
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        StartRotation();
    }

    public void StartRotation()
    {
        canRotate = true;
    }

    public void StopRotation()
    {
        canRotate = false;
    }
}
