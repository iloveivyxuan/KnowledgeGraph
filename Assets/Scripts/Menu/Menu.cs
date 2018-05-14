using HoloToolkit.Unity;
using UnityEngine;

public class Menu : MonoBehaviour {
    public bool IsOnMenuState;
    public GameObject ButtonsWrapper;
    public GameObject GraphWrapper;
    public GameObject InfoGraph;

    private void Start()
    {
        IsOnMenuState = true;
    }

    public void ChangeSplitStatus()
    {
        if (IsOnMenuState)
        {
            SplitMenu();
            changeMenuStatus();
        }
        else
        {
            CloseMenu();
            changeMenuStatus();
        }
    }

    public void Appear()
    {
        changeMenuStatus();
        gameObject.GetComponent<Tagalong>().enabled = true;
        iTween.ScaleTo(ButtonsWrapper, iTween.Hash("x", 1, "y", 1, "z", 1, "easeType", "easeInOutExpo", "delay", 0.1));
        iTween.MoveTo(ButtonsWrapper, iTween.Hash("position", new Vector3(0, 0, 0), "islocal", true, "easeType", "easeInOutExpo", "delay", .2));
        iTween.MoveTo(InfoGraph, iTween.Hash("position", new Vector3(0, 0.16f, 0), "islocal", true, "easeType", "easeInOutExpo", "delay", .2));
        iTween.ScaleTo(InfoGraph, iTween.Hash("x", 0.005, "y", 0.005, "z", 0.005, "easeType", "easeInOutExpo", "delay", 0.2));
    }

    public void Disappear()
    {
        changeMenuStatus();
        iTween.ScaleTo(ButtonsWrapper, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
        iTween.ScaleTo(InfoGraph, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
        gameObject.GetComponent<Tagalong>().enabled = false;
    }

    private void SplitMenu()
    {
        iTween.MoveBy(ButtonsWrapper, iTween.Hash("y", -0.25, "easeType", "easeInOutExpo", "delay", .1));
        iTween.RotateBy(ButtonsWrapper, iTween.Hash("x", .15, "easeType", "easeInOutBack", "delay", .1));
        iTween.MoveBy(GraphWrapper, iTween.Hash("y", 0.25, "easeType", "easeInOutExpo", "delay", .1));
    }

    private void CloseMenu()
    {
        iTween.MoveBy(ButtonsWrapper, iTween.Hash("y", 0.25, "easeType", "easeInOutExpo", "delay", .1));
        iTween.RotateBy(ButtonsWrapper, iTween.Hash("x", -0.15, "easeType", "easeInOutBack", "delay", .1));
        iTween.MoveBy(GraphWrapper, iTween.Hash("y", -0.25, "easeType", "easeInOutExpo", "delay", .1));
    }

    private void changeMenuStatus()
    {
        IsOnMenuState = !IsOnMenuState;
    }
}
