using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class AutomateButton : MonoBehaviour, IInputClickHandler {
    public GameObject InfoGraph;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        InfoGraph.GetComponent<AutoRotation>().isRotating = !InfoGraph.GetComponent<AutoRotation>().isRotating;
    }
}
