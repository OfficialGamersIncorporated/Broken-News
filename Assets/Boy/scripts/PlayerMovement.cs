using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 10.0f;
    float fastSpeed = 15.0f;
    CharacterController movement;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float usedSpeed = speed;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
       
        if(horizontal < 0)
        {
            usedSpeed = fastSpeed;
        }

        moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection *= usedSpeed;
        movement.SimpleMove(moveDirection);
    }
}
