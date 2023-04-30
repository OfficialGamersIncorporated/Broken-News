using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperCollision : MonoBehaviour
{
    public GameObject theWorld;
    new public ParticleSystem particleSystem;
    private Rigidbody rb;
    private bool hasCollided = false;
    //public float cylinderLength = 2.0f;
    public float spinSpeed = 550f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.SetParent(theWorld.transform);

        // I hate unity I hate unity I hate unity
        var main = particleSystem.main;
        main.customSimulationSpace = theWorld.transform;
    }
    void FixedUpdate()
    {
        // Update the rotation of the cylinder
        //transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        // Update the rotation of the cylinder
        if (!hasCollided)
        {
            /*Vector3 velocity = rb.velocity;
            Vector3 gravity = Physics.gravity;

            // Calculate the angle between the velocity and gravity vectors
            float angle = Vector3.Angle(velocity, -gravity);

            // Calculate the axis of rotation using the cross product of the velocity and gravity vectors
            Vector3 axis = Vector3.Cross(velocity, -gravity);

            // Apply the rotation to the cylinder
            transform.rotation = Quaternion.AngleAxis(angle, axis);
            // Get the velocity and gravity vectors of the rigidbody*/
            transform.Rotate(0f, 0f, spinSpeed * Time.fixedDeltaTime);
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!hasCollided && collision.gameObject.CompareTag("Door")) {
            GameplayManager.Singleton.IncrementScore();
            particleSystem.Emit(30);
            //particleSystem.Play();
        }

        // Print a message to the console when a collision occurs
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        hasCollided = true;
        //GetComponent<Rigidbody>().isKinematic = true;

        //MAPPY MAKE SCALL HERER

    }

    // Update is called once per frame
    void Update()
    {
    }
}
