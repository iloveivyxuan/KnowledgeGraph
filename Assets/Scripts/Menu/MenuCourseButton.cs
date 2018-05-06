using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuCourseButton : MonoBehaviour, IInputClickHandler {
    public GameObject Menu;
    public GameObject Buttons;
    public GameObject Graph;
    public GameObject CourseCards;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Menu.GetComponent<Menu>().onMenu = !Menu.GetComponent<Menu>().onMenu;
        if (!Menu.GetComponent<Menu>().onMenu)
        {
            MenuOpen();
            CourseCards.GetComponent<CourseCardsAnimation>().AppearCards();
            CourseCards.GetComponent<CourseCardsAnimation>().SpreadCards();
        }
        else
        {
            CourseCards.GetComponent<CourseCardsAnimation>().PutTogether();
            MenuClose();
        }
    }

    private void MenuOpen()
    {
        iTween.MoveBy(Buttons, iTween.Hash("y", -0.25, "easeType", "easeInOutExpo", "delay", .1));
        iTween.RotateBy(Buttons, iTween.Hash("x", .15, "easeType", "easeInOutBack", "delay", .1));
        iTween.MoveBy(Graph, iTween.Hash("y", 0.25, "easeType", "easeInOutExpo", "delay", .1));
    }

    private void MenuClose()
    {
        iTween.MoveBy(Buttons, iTween.Hash("y", 0.25, "easeType", "easeInOutExpo", "delay", .1));
        iTween.RotateBy(Buttons, iTween.Hash("x", -0.15, "easeType", "easeInOutBack", "delay", .1));
        iTween.MoveBy(Graph, iTween.Hash("y", -0.25, "easeType", "easeInOutExpo", "delay", .1));
    }
}
