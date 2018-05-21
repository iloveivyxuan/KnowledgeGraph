using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeywordsWrapper : MonoBehaviour {
    public GameObject KeywordToInitiate;
    public GameObject Camera;
    public GameObject WordsManager;

    public void Appear()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "z", 1));
        gameObject.transform.rotation = Quaternion.Euler(Camera.transform.rotation.eulerAngles);
    }

    public void Disappear()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("x", 0, "y", 0, "z", 0, "easeType", "easeInOutExpo", "delay", 0.2));
    }

    public void CreateKeywordPrefabs()
    {
        List<string> keywords = WordsManager.GetComponent<WordsManager>().Words;
        int lines = keywords.Count / 3 + 1;
        foreach (string keyword in keywords)
        {
            GameObject keywordObject = Instantiate(KeywordToInitiate, new Vector3(0, 0.124f, 2.2f), Quaternion.identity);
            keywordObject.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = keyword;
            keywordObject.transform.parent = transform;
            keywordObject.GetComponent<KeywordInfo>().Name = keyword;
        }
    }
}
