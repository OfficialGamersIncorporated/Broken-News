using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float carSpeedMod;
    Rigidbody carbody;

    
    // Start is called before the first frame update
    void Start()
    {
        if (Vector3.Dot(transform.right, Vector3.right) > 0) {
            carSpeedMod = 5 + (Random.Range(0, 20) ^ 2); //Random.Range(5, 20);
        } else {
            carSpeedMod = 15 + (Random.Range(5, 25) ^ 2); //Random.Range(15, 20);
        }
        carbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += carSpeedMod * Time.deltaTime * -transform.right;
        if (carSpeedMod > 0)
            carbody.velocity = carSpeedMod * -transform.right;

        if (transform.position.y < -10) {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            carbody.constraints = 0;
        }
        else if (collision.gameObject.CompareTag("Car")) {
            carbody.constraints = 0;
            carSpeedMod = 0;
        }
    }

}
