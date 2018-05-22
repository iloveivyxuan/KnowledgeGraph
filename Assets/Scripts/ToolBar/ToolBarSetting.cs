using System.Collections.Generic;
using UnityEngine;

public class ToolBarSetting : MonoBehaviour {
    public List<GameObject> Children;
    private int index;

    public void GetChildren()
    {
        Children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                Children.Add(child.gameObject);
            }
        }
    }

    public void SetToolsPosition()
    {
        for (int i = 0; i < Children.Count; i++)
        {
            if (Children[i].activeSelf)
            {
                Children[i].transform.localPosition = new Vector3(0.0802f * i - (Children.Count - 1) * 0.0802f / 2f, -0.1f, 0);
            }
        }
    }
}
