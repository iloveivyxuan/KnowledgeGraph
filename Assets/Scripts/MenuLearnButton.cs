using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.InputModule.Utilities.Interactions;
using HoloToolkit.Unity;
using UnityEngine;

public class MenuLearnButton : MonoBehaviour, IInputClickHandler {
    public GameObject Menu;
    public GameObject Buttons;
    public GameObject InfoGraph;
    public GameObject ToolBar;
    public GameObject ToolBarWrapper;
    private bool onLearn;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Menu.GetComponent<Menu>().onMenu = false;
        onLearn = !Menu.GetComponent<Menu>().onMenu;
        if (onLearn)
        {
            iTween.ScaleTo(Buttons, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
            iTween.MoveTo(InfoGraph, iTween.Hash("position", Menu.transform.position / 2, "easeType", "easeInOutExpo", "delay", .1));
            iTween.ScaleTo(InfoGraph, iTween.Hash("x", 0.008, "y", 0.008, "z", 0.008, "easeType", "easeInOutExpo", "delay", 0.1));
            Menu.GetComponent<Tagalong>().enabled = false;
            InfoGraph.GetComponent<TwoHandManipulatable>().enabled = true;
            ToolBarWrapper.SetActive(true);
            ToolBar.GetComponent<ToolBarSetting>().GetChildren();
            ToolBar.GetComponent<ToolBarSetting>().SetToolsPosition();
        }
    }
}
