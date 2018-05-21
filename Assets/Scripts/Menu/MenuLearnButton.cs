using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.InputModule.Utilities.Interactions;
using HoloToolkit.Unity;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;

public class MenuLearnButton : MonoBehaviour, IInputClickHandler {
    public GameObject Menu;
    public GameObject InfoGraph;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Menu.GetComponent<Menu>().DisappearWithoutInfoGraph();
        Menu.GetComponent<Menu>().EnlargeInfoGraph();
        InfoGraph.GetComponent<TapToPlace>().enabled = true;
        InfoGraph.GetComponent<TapToPlace>().PlaceGameobject();
        Menu.GetComponent<Menu>().EnlargeInfoGraph();
    }
}
