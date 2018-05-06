using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuStackButton : MonoBehaviour, IInputClickHandler {
    public GameObject KeywordsWrapper;
    public GameObject Menu;
    public GameObject Buttons;
    public GameObject InfoGraph;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        AppearKeywordWrapper();
        MenuClose();
    }

    private void MenuClose()
    {
        Menu.GetComponent<Menu>().onMenu = false;
        iTween.ScaleTo(Buttons, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
        iTween.ScaleTo(InfoGraph, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
        Menu.GetComponent<Tagalong>().enabled = false;
    }

    private void AppearKeywordWrapper()
    {
        iTween.ScaleTo(KeywordsWrapper, iTween.Hash("x", 1, "y", 1, "z", 1, "easeType", "easeInOutExpo", "delay", 0.1));
    }
}
