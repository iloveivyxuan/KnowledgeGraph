using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuCourseButton : MonoBehaviour, IInputClickHandler {
    public GameObject Buttons;
    public GameObject Graph;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        iTween.MoveBy(Buttons, iTween.Hash("y", -0.25, "easeType", "easeInOutExpo", "delay", .1));
        iTween.RotateBy(Buttons, iTween.Hash("x", .15, "easeType", "easeInOutBack", "delay", .1));
        iTween.MoveBy(Graph, iTween.Hash("y", 0.25, "easeType", "easeInOutExpo", "delay", .1));
    }
}
