using UnityEngine;

[System.Serializable]
public class InfoPoint
{
    public Label label;
    public string type;
    public string id;
    public Vector3 position;

    public static InfoPoint CreateFromJSON(string dataAsJson)
    {
        return JsonUtility.FromJson<InfoPoint>(dataAsJson);
    }
}

[System.Serializable]
public class Label
{
    public string en;
    public string zh;

    public static Label CreateFromJSON(string dataAsJson)
    {
        return JsonUtility.FromJson<Label>(dataAsJson);
    }
}

[System.Serializable]
public class InfoEdge
{
    public string source;
    public string target;

    public static InfoEdge CreateFromJSON(string dataAsJson)
    {
        return JsonUtility.FromJson<InfoEdge>(dataAsJson);
    }
}
