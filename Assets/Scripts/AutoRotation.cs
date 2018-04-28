using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour {
    private Vector3 updateRotation;
	
	// Update is called once per frame
	void Update () {
        updateRotation = new Vector3(0.1f, 0.2f, 0.3f);
        transform.localRotation *= Quaternion.Euler(updateRotation);
	}
}
