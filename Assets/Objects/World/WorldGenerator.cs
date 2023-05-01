using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

    public float Speed = 10;
    public float RunSpeedMultiplier = 2;
    //public float PlayerMaxSpeed = 20;
    public float Spacing = 10;
    public bool IsSprinting = false;
    public GameObject Ground;
    //public SpeedUpCollider SpeedUpCollider;
    public static WorldGenerator Singleton;

    void Awake() {
        Singleton = this;
    }

    private void Update() {
        float deltaTime = Time.deltaTime; //Time.fixedDeltaTime;

        float currentSpeed = Speed;
        //if(SpeedUpCollider.PlayerTouching) {
        //    currentSpeed = PlayerMaxSpeed;
        //}
        if(Input.GetButton("Fire3")) {
            currentSpeed = Speed * RunSpeedMultiplier; //PlayerMaxSpeed;
            IsSprinting = true;
        }
        else
        {
            IsSprinting = false;
        }


        transform.position += currentSpeed * deltaTime * Vector3.left;
        float xOffset = transform.position.x % (Spacing * 2);
        Ground.transform.position = new Vector3(xOffset, transform.position.y, transform.position.z);
    }
}
