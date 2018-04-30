using UnityEngine;

public class AutoRotation : MonoBehaviour {
    public bool isRotating;
    private Vector3 updateRotation;

    private void Start()
    {
        isRotating = true;
    }

    // Update is called once per frame
    void Update () {
        if (isRotating)
        {
            updateRotation = new Vector3(0.1f, 0.2f, 0.3f);
            transform.localRotation *= Quaternion.Euler(updateRotation);
        }
	}
}
