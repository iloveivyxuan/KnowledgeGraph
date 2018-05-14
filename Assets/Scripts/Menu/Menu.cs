using UnityEngine;

public class Menu : MonoBehaviour {
    public bool IsOnMenuState;
    public GameObject ButtonsWrapper;
    public GameObject GraphWrapper;

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
