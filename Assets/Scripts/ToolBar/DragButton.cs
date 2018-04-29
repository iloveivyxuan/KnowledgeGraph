using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class DragButton : MonoBehaviour, IInputClickHandler {
    public GameObject InfoGraph;
    private bool IsDraggingEnabled;

    private void Start()
    {
        IsDraggingEnabled = InfoGraph.GetComponent<HandDraggable>().IsDraggingEnabled;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        IsDraggingEnabled = !IsDraggingEnabled;
        InfoGraph.GetComponent<HandDraggable>().IsDraggingEnabled = IsDraggingEnabled;
    }
}
