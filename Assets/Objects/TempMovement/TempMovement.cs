using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement : MonoBehaviour {

    public float MoveSpeed = 5;
    public CharacterController CharControl;

    void Start() {
        CharControl = GetComponent<CharacterController>();
    }
    void Update() {
        CharControl.SimpleMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * MoveSpeed);
    }
}
