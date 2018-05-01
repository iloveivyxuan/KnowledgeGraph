﻿using System.Collections.Generic;
using UnityEngine;

public class CourseCardsAnimation : MonoBehaviour {
    public GameObject Camera;
    public List<GameObject> Children;

    private void Start()
    {
        getChild();
    }

    private void getChild()
    {
        foreach (Transform child in transform)
        {
            Children.Add(child.gameObject);
        }
    }

    public void AppearCards()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "z", 1, "easeType", "easeInOutExpo", "delay", 0.1));
    }

    public void SpreadCards()
    {
        for (int i = 0; i < Children.Count; i++)
        {
            iTween.RotateBy(Children[i], iTween.Hash("y", 0.03 * i, "easeType", "easeInOutExpo", "delay", 0.6 + 0.1 * i));
        }
    }

    public void PutTogether()
    {
        for (int i = 0; i < Children.Count; i++)
        {
            iTween.RotateTo(Children[i], iTween.Hash("y", Camera.transform.rotation.eulerAngles.y, "easeType", "easeInOutExpo", "delay", 0.1));
        }
        iTween.ScaleTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
    }
}
