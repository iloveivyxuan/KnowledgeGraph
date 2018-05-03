using UnityEngine;

public class Line : MonoBehaviour {
    public Vector3 SphericalStartPosition;
    public Vector3 SphericalEndPosition;
    public Vector3 HierarchyStartPosition;
    public Vector3 HierarchyEndPosition;

    public bool IsInSameLayer()
    {
        bool isInSameLayer = HierarchyStartPosition.z == HierarchyEndPosition.z;
        return isInSameLayer;
    }
}
