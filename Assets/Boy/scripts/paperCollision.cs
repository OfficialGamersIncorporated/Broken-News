using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperCollision : MonoBehaviour
{
    public GameObject theWorld;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        // Print a message to the console when a collision occurs
        transform.SetParent(theWorld.transform);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().isKinematic = true;
        //MAPPY MAKE SCALL HERER
    }

    // Update is called once per frame
    void Update()
    {
    }
}
