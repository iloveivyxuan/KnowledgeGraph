using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CourseCardInteraction : MonoBehaviour, IInputClickHandler, IFocusable {
    public GameObject WordsManager;
    public float DefaultHeight;
    public GameObject InfoGraph;

    public void OnFocusEnter()
    {
        iTween.ScaleAdd(gameObject, iTween.Hash("x", 0.0001, "y", 0.0001, "easeType", "easeInOutExpo"));
    }

    public void OnFocusExit()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", 0.0005, "y", 0.0005, "easeType", "easeInOutExpo"));
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        DefaultHeight = WordsManager.GetComponent<WordsManager>().GetGraphTransitionHeight(GetComponent<CourseInfo>().Words);
    }
}
