using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using UnityEngine;

public class StackPageManager : MonoBehaviour {
    public GameObject Keyboard;
    public GameObject KeywordsWrapper;

	void Update () {
        if (Keyboard.activeSelf)
        {
            KeywordsWrapper.GetComponent<Tagalong>().enabled = false;
        }
        else
        {
            KeywordsWrapper.GetComponent<Tagalong>().enabled = true;
        }
	}
}
