using System.Collections.Generic;
using HoloToolkit.Unity;
using UnityEngine;
using UnityEngine.UI;

public class KeywordsWrapper : MonoBehaviour {
    public GameObject KeywordToInitiate;
    public GameObject Contents;
    public GameObject Camera;
    public GameObject WordsManager;

    public void Appear()
    {
        EnableTagalong();
        iTween.ScaleTo(Contents, iTween.Hash("x", 1, "y", 1, "z", 1, "easeType", "easeInOutExpo"));
        gameObject.transform.rotation = Quaternion.Euler(Camera.transform.rotation.eulerAngles);   
    }

    public void Disappear()
    {
        iTween.ScaleTo(Contents, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0));
        DisableTagalong();
    }

    public void CreateKeywordPrefabs()
    {
        List<string> keywords = WordsManager.GetComponent<WordsManager>().Words;
        int lines = keywords.Count / 3 + 1;
        foreach (string keyword in keywords)
        {
            GameObject keywordObject = Instantiate(KeywordToInitiate, new Vector3(0, 0.124f, 2.2f), Quaternion.identity);
            keywordObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = keyword;
            keywordObject.transform.parent = Contents.transform;
            keywordObject.GetComponent<KeywordInfo>().Name = keyword;
        }
    }

    private void EnableTagalong()
    {
        GetComponent<Tagalong>().enabled = true;
    }

    private void DisableTagalong()
    {
        GetComponent<Tagalong>().enabled = false;
    }
}
