using HoloToolkit.Unity.InputModule;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;

public class MoveButton : MonoBehaviour, IInputClickHandler {
    public GameObject InfoGraph;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        InfoGraph.GetComponent<TapToPlace>().IsPlacingEnabled = !InfoGraph.GetComponent<TapToPlace>().IsPlacingEnabled;
    }
}
