using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class InfoGraphInteractions : MonoBehaviour, ISpeechHandler {

    private bool canRotate;
    private Vector3 updateRotation;

    // Update is called once per frame
    void Update () {
        if (canRotate)
        {
            updateRotation = Vector3.zero;
            updateRotation.z = 0.1f;
            transform.localRotation *= Quaternion.Euler(updateRotation);
        }
	}

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch (eventData.RecognizedText.ToLower())
        {
            case "rotate":
                startRotation();
                break;
            case "stop":
                stopRotation();
                break;
        }
    }

    private void startRotation()
    {
        canRotate = true;
    }

    private void stopRotation()
    {
        canRotate = false;
    }
}
