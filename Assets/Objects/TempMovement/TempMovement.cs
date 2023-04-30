using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement : MonoBehaviour {

    public float MoveSpeed = 5;
    CharacterController CharControl;
    Animator animator;

    void Start() {
        CharControl = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update() {
        CharControl.SimpleMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * MoveSpeed);
        
    }
}
