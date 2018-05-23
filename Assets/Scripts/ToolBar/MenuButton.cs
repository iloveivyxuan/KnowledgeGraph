using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuButton : MonoBehaviour, IInputClickHandler {
    public GameObject Menu;
    public GameObject Buttons;
    public GameObject ToolBarWrapper;
    public GameObject InfoGraph;
    public GameObject KeywordsWrapper;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Menu.GetComponent<Menu>().AppearWithoutInfoGraph();
        ToolBarWrapper.SetActive(false);
        InfoGraph.GetComponent<Transition>().TransformToSpherical();
        InfoGraph.GetComponent<GraphInformation>().DisappearLabelToPoints();
        KeywordsWrapper.SetActive(true);
    }
}
