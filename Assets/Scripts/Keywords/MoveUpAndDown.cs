using UnityEngine;

public class MoveUpAndDown : MonoBehaviour {

	void Update () {
        iTween.MoveBy(gameObject, iTween.Hash("y", 0.01, "loopType", "pingPong", "delay", 0));
    }
}
