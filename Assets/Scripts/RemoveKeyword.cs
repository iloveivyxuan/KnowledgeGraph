using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class RemoveKeyword : MonoBehaviour, IInputClickHandler {

    public void OnInputClicked(InputClickedEventData eventData)
    {
        string keyword = gameObject.transform.parent.gameObject.GetComponent<KeywordInfo>().Name;
        GameObject wordsManager = GameObject.FindGameObjectWithTag("WordsManager");
        wordsManager.GetComponent<WordsManager>().Words.Remove(keyword);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
