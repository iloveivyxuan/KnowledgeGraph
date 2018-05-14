using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuCourseButton : MonoBehaviour, IInputClickHandler {
    public GameObject Menu;
    public GameObject CourseCards;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Menu.GetComponent<Menu>().ChangeSplitStatus();
        if (!Menu.GetComponent<Menu>().IsOnMenuState)
        {
            CourseCards.GetComponent<CourseCardsAnimation>().Appear();
            CourseCards.GetComponent<CourseCardsAnimation>().Spread();
        }
        else
        {
            CourseCards.GetComponent<CourseCardsAnimation>().PutTogether();
        }
    }
}
