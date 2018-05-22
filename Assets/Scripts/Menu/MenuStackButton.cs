using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class MenuStackButton : MonoBehaviour, IInputClickHandler {
    public GameObject KeywordsWrapper;
    public GameObject Menu;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        KeywordsWrapper.GetComponent<KeywordsWrapper>().Appear();
        Menu.GetComponent<Menu>().Disappear();
    }
}
