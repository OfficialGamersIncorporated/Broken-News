using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float carSpeedMod;
    public Vector2 SpeedRange_SameDir = new Vector2(10, 20);
    public Vector2 SpeedRange_Oncoming = new Vector2(0, 15);
    Rigidbody carbody;

    
    // Start is called before the first frame update
    void Start()
    {
        if (Vector3.Dot(transform.forward, Vector3.right) > 0) {
            carSpeedMod = WorldGenerator.Singleton.Speed + SpeedRange_SameDir.x + Mathf.Pow(Random.Range(0, SpeedRange_SameDir.y) / 10, 2); //Random.Range(15, 20);
        } else {
            carSpeedMod = SpeedRange_Oncoming.x + Mathf.Pow(Random.Range(0, SpeedRange_Oncoming.y) / 10, 2); //Random.Range(5, 20);
        }
        carbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += carSpeedMod * Time.deltaTime * transform.forward;
        if (carSpeedMod > 0)
            carbody.velocity = carSpeedMod * transform.forward;

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
