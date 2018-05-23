using UnityEngine;

public class GraphInteractions : MonoBehaviour {
    public void DestroyLayers()
    {
        GameObject[] layers = GameObject.FindGameObjectsWithTag("Layer");
        foreach (GameObject layer in layers)
        {
            Destroy(layer);
        }
    }

    public void AppearLayers()
    {
        GameObject[] layers = GameObject.FindGameObjectsWithTag("Layer");
        foreach (GameObject layer in layers)
        {
            layer.SetActive(false);
        }
    }

    public void DisappearLayers()
    {
        GameObject[] layers = GameObject.FindGameObjectsWithTag("Layer");
        foreach (GameObject layer in layers)
        {
            layer.SetActive(true);
        }
    }
}
