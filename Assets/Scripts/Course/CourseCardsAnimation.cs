using System.Collections.Generic;
using UnityEngine;

public class CourseCardsAnimation : MonoBehaviour {
    public GameObject CardsWrapper;
    public GameObject Camera;
    public List<GameObject> Children;
    private float rotationNumber;

    private void Start()
    {
        GetChild();
    }

    public void ChangeSpreadStatus(bool isOnMenu)
    {
        if (!isOnMenu)
        {
            Appear();
            Spread();
        }
        else
        {
            PutTogether();
        }
    }

    private void GetChild()
    {
        foreach (Transform child in transform)
        {
            Children.Add(child.gameObject);
        }
    }

    private void Appear()
    {
        CardsWrapper.transform.rotation = Quaternion.Euler( new Vector3(Camera.transform.rotation.eulerAngles.x, Camera.transform.rotation.eulerAngles.y, 0));
        iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "z", 1, "easeType", "easeInOutExpo", "delay", 0.1));
    }

    private void Spread()
    {
        rotationNumber = 0.03f;
        for (int i = 0; i < Children.Count; i++)
        {
            iTween.RotateBy(Children[i], iTween.Hash("y", (i + 1) / 2 * rotationNumber, "easeType", "easeInOutExpo", "delay", 0.6 + 0.1 * (i + 1) / 2));
            rotationNumber *= -1;
        }
    }

    private void PutTogether()
    {
        for (int i = 0; i < Children.Count; i++)
        {
            iTween.RotateTo(Children[i], iTween.Hash("y", Camera.transform.rotation.eulerAngles.y, "easeType", "easeInOutExpo", "delay", 0.1));
        }
        iTween.ScaleTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.1));
    }
}
