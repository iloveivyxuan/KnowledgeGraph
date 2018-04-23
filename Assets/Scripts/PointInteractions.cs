using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class PointInteractions : MonoBehaviour, IFocusable, IInputClickHandler {

    public Color NormalColor;
    public Color HighlightColor;
    private Renderer pointRenderer;
    private Material pointMaterialInstance;
    private bool canRotate;
    //private Vector3 initialRotation;
    private Vector3 updateRotation;


    #region Unity APIs

    private void Awake()
    {
        pointRenderer = gameObject.GetComponent<Renderer>();
        pointMaterialInstance = pointRenderer.material;
        //initialRotation = gameObject.transform.localRotation.eulerAngles;
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
            transform.localRotation *= Quaternion.Euler(updateRotation);
        }
    }

    // 当 MonoBehaviour 将被销毁时调用此函数
    private void OnDestroy()
    {
        Destroy(pointMaterialInstance);
    }

    #endregion


    #region InputImplementation

    public void OnFocusEnter()
    {
        pointMaterialInstance.color = HighlightColor;
    }

    public void OnFocusExit()
    {
        pointMaterialInstance.color = NormalColor;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        StartRotation();
    }

    #endregion


    public void StartRotation()
    {
        canRotate = true;
    }
}
