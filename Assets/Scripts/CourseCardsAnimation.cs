using System.Collections.Generic;
using UnityEngine;

public class CourseCardsAnimation : MonoBehaviour {
    public List<GameObject> Children;

    private void getChild()
    {
        foreach (Transform child in transform)
        {
            Children.Add(child.gameObject);
        }
    }

    public void AppearCards()
    {
        iTween.ScaleFrom(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.5));
    }

    public void SpreadCards()
    {
        getChild();
        for (int i = 0; i < Children.Count; i++)
        {
            iTween.MoveBy(Children[i], iTween.Hash("x", -0.25 * i, "easeType", "easeInOutExpo", "delay", 1 + 0.1 * i));
            iTween.RotateBy(Children[i], iTween.Hash("y", 0.04 * i, "easeType", "easeInOutExpo", "delay", 1 + 0.1 * i));
        }
    }
}
