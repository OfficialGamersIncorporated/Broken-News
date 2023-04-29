using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpCollider : MonoBehaviour {

    public bool PlayerTouching = false;

    private void FixedUpdate() {
        PlayerTouching = false;
    }

    private void OnCollisionStay(Collision collision) {
        PlayerTouching = true;
    }
}
