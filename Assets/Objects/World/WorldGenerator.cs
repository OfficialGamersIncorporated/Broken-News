using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

    public float Speed = 10;
    public float PlayerMaxSpeed = 20;
    public float Spacing = 10;
    public GameObject Ground;
    public SpeedUpCollider SpeedUpCollider;

    void Start() {
        
    }
    void Update() {
        float currentSpeed = Speed;
        if(SpeedUpCollider.PlayerTouching) {
            currentSpeed = PlayerMaxSpeed;
        }

        transform.position += currentSpeed * Time.deltaTime * Vector3.left;
        float xOffset = transform.position.x % (Spacing * 2);
        Ground.transform.position = new Vector3(xOffset, transform.position.y, transform.position.z);
    }
}
