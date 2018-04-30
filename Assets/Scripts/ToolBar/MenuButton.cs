using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;
using UnityEngine;

public class MenuButton : MonoBehaviour, IInputClickHandler {
    public GameObject Menu;
    public GameObject MenuPosition;
    public GameObject Buttons;
    public GameObject ToolBar;
    public GameObject InfoGraph;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Menu.GetComponent<Tagalong>().enabled = true;
        Menu.GetComponent<Menu>().onMenu = true;
        iTween.ScaleTo(Buttons, iTween.Hash("x", 1, "y", 1, "z", 1, "easeType", "easeInOutExpo", "delay", 0.1));
        iTween.MoveTo(Buttons, iTween.Hash("position", new Vector3(0, 0, 0), "islocal", true, "easeType", "easeInOutExpo", "delay", .2));
        ToolBar.SetActive(false);
        iTween.MoveTo(InfoGraph, iTween.Hash("position", new Vector3(0, 0.16f, 0), "islocal", true, "easeType", "easeInOutExpo", "delay", .2));
    }
}
