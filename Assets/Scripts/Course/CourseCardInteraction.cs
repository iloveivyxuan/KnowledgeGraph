using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;
using UnityEngine;

public class CourseCardInteraction : MonoBehaviour, IInputClickHandler, IFocusable {
    public GameObject WordsManager;
    public float DefaultHeight;
    public GameObject InfoGraph;
    public GameObject Menu;
    public GameObject CourseCards;
    private bool cardOnShow;

    void Start()
    {
        cardOnShow = false;
    }

    public void OnFocusEnter()
    {
        iTween.ScaleAdd(gameObject, iTween.Hash("x", 0.0001, "y", 0.0001, "easeType", "easeInOutExpo", "delay", 0));
    }

    public void OnFocusExit()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", 0.0005, "y", 0.0005, "easeType", "easeInOutExpo"));
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        cardOnShow = !cardOnShow;
        if (cardOnShow)
        {
            DefaultHeight = WordsManager.GetComponent<WordsManager>().GetGraphTransitionHeight(GetComponent<CourseInfo>().Words);
            ChangeInfoGraph();
            OnlyAppearClickedCard(gameObject);
            Menu.GetComponent<Tagalong>().enabled = false;
        }
        else
        {
            //DefaultHeight = WordsManager.GetComponent<WordsManager>().GetGraphTransitionHeight(GetComponent<CourseInfo>().Words);
            RestoreInfoGraph();
            RestoreCards();
            Menu.GetComponent<Tagalong>().enabled = true;
        }
    }

    private void ChangeInfoGraph()
    {
        InfoGraph.GetComponent<SphereCollider>().enabled = false;
        iTween.MoveTo(InfoGraph, iTween.Hash("x", -0.22f, "y", -0.26f, "islocal", true, "easeType", "easeInOutExpo", "delay", .1));
        iTween.ScaleTo(InfoGraph, iTween.Hash("x", 0.01, "y", 0.01, "z", 0.01, "easeType", "easeInOutExpo", "delay", 0.1));
    }

    private void RestoreInfoGraph()
    {
        InfoGraph.GetComponent<SphereCollider>().enabled = true;
        iTween.MoveTo(InfoGraph, iTween.Hash("x", 0f, "y", 0.16f, "islocal", true, "easeType", "easeInOutExpo", "delay", .1));
        iTween.ScaleTo(InfoGraph, iTween.Hash("x", 0.005, "y", 0.005, "z", 0.005, "easeType", "easeInOutExpo", "delay", 0.1));
    }

    private void OnlyAppearClickedCard(GameObject clickedCard)
    {
        List<GameObject> cards = CourseCards.GetComponent<CourseCardsAnimation>().Children;
        foreach (GameObject card in cards)
        {
            if (card != clickedCard)
            {
                card.SetActive(false);
            }
        }
        GetComponent<RectTransform>().localPosition = new Vector3(0.15f, 0, -0.39f);
    }

    private void RestoreCards()
    {
        List<GameObject> cards = CourseCards.GetComponent<CourseCardsAnimation>().Children;
        foreach (GameObject card in cards)
        {
            if (card != gameObject)
            {
                card.SetActive(true);
            }
        }
        GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
    }
}
