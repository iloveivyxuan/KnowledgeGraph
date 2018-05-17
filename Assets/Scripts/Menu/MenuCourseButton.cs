using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuCourseButton : MonoBehaviour, IInputClickHandler {
    public GameObject Menu;
    public GameObject CourseCards;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Menu.GetComponent<Menu>().ChangeSplitStatus();
        bool isOnMenu = Menu.GetComponent<Menu>().IsOnMenu;
        CourseCards.GetComponent<CourseCardsAnimation>().ChangeSpreadStatus(isOnMenu);
    }
}
