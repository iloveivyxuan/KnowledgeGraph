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
        InfoGraph.GetComponent<Transition>().EnlargeTo(0.008f);
        InfoGraph.GetComponent<Transition>().MoveToCenter();
        InfoGraph.GetComponent<TapToPlace>().enabled = true;
        //InfoGraph.GetComponent<TapToPlace>().PlaceGameobject();  这里有问题，不知道为什么无法获得point的focus事件
    }
}
