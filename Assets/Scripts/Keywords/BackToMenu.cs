using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class BackToMenu : MonoBehaviour, IInputClickHandler {
    public GameObject Menu;
    public GameObject KeywordsWrapper;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        KeywordsWrapper.GetComponent<KeywordsWrapper>().Disappear();
        Menu.GetComponent<Menu>().Appear();
    }
}
