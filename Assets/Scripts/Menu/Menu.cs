using HoloToolkit.Unity;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject ButtonsWrapper;
    public GameObject GraphWrapper;
    public GameObject BackgroundWrapper;
    public GameObject InfoGraph;
    private StatusManager statusManager;

    public void Change(StatusManager.Status statusFrom, StatusManager.Status statusTo)
    {
        if (statusFrom == StatusManager.Status.Menu && statusTo == StatusManager.Status.CourseIndex)
        {
            Split();
            ChangeTagalongSetting();
        }
        else if (statusFrom == StatusManager.Status.CourseIndex && statusTo == StatusManager.Status.Menu)
        {
            Close();
            RestoreTagalongSetting();
        }
    }

    public void Appear()
    {
        GetComponent<Tagalong>().enabled = true;
        iTween.ScaleTo(ButtonsWrapper, iTween.Hash("x", 1, "y", 1, "z", 1, "easeType", "easeInOutExpo", "delay", 0.1));
        iTween.ScaleTo(GraphWrapper, iTween.Hash("x", 1, "y", 1, "z", 1, "easeType", "easeInOutExpo", "delay", 0.1));
    }

    public void Disappear()
    {
        iTween.ScaleTo(ButtonsWrapper, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
        iTween.ScaleTo(GraphWrapper, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
        GetComponent<Tagalong>().enabled = false;
    }

    public void DisappearWithoutInfoGraph()
    {
        iTween.ScaleTo(ButtonsWrapper, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
        iTween.ScaleTo(BackgroundWrapper, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
        GetComponent<Tagalong>().enabled = false;
    }

    private void Split()
    {
        iTween.MoveBy(ButtonsWrapper, iTween.Hash("y", -0.25, "easeType", "easeInOutExpo", "delay", .1));
        iTween.RotateBy(ButtonsWrapper, iTween.Hash("x", .15, "easeType", "easeInOutBack", "delay", .1));
        iTween.MoveBy(GraphWrapper, iTween.Hash("y", 0.25, "easeType", "easeInOutExpo", "delay", .1));
    }

    private void Close()
    {
        iTween.MoveBy(ButtonsWrapper, iTween.Hash("y", 0.25, "easeType", "easeInOutExpo", "delay", .1));
        iTween.RotateBy(ButtonsWrapper, iTween.Hash("x", -0.15, "easeType", "easeInOutBack", "delay", .1));
        iTween.MoveBy(GraphWrapper, iTween.Hash("y", -0.25, "easeType", "easeInOutExpo", "delay", .1));
    }

    private void ChangeTagalongSetting()
    {
        GetComponent<Tagalong>().MinimumHorizontalOverlap = 0.95f;
        GetComponent<Tagalong>().MinimumVerticalOverlap = 0.05f;
    }

    private void RestoreTagalongSetting()
    {
        GetComponent<Tagalong>().MinimumHorizontalOverlap = 0.63f;
        GetComponent<Tagalong>().MinimumVerticalOverlap = 0.6f;
    }
}
