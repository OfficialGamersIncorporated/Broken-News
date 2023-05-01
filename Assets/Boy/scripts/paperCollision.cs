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
        // record score
        if(!hasCollided) {
            
            if(collision.gameObject.CompareTag("Door"))
            {
                GameplayManager gameMan = GameplayManager.Singleton;
                Vector3 doorPos = collision.transform.parent.position;
                Vector3 doorWorldPos = theWorld.transform.InverseTransformPoint(doorPos);

                if(gameMan.AlreadyHitHouses.Contains(doorWorldPos)) {
                    GameplayManager.Singleton.IncrementScore(-10);
                } else {
                    gameMan.AlreadyHitHouses.Add(doorWorldPos);
                    float distanceDivider = 2;
                    int distanceBasedScore = (int)Mathf.Round(9 - Mathf.Clamp((transform.position - doorPos).magnitude * distanceDivider, 0, 10));
                    print(distanceBasedScore);
                    GameplayManager.Singleton.IncrementScore(distanceBasedScore);
                    particleSystem.Emit(30);
                    //particleSystem.Play();
                }
            }
            else if (collision.gameObject.CompareTag("Pedestrian"))
            {
                GameplayManager gameMan = GameplayManager.Singleton;


                if (gameMan.AlreadyHitPedestrian.Contains(collision.gameObject))
                {
                    GameplayManager.Singleton.IncrementScore(-1);
                }
                else
                {
                    gameMan.AlreadyHitPedestrian.Add(collision.gameObject);
                    GameplayManager.Singleton.IncrementScore(5);
                    particleSystem.Emit(30);
                    //particleSystem.Play();
                    pedestrianAnimationSwitcher itsHit = collision.gameObject.GetComponent<pedestrianAnimationSwitcher>();
                    if(itsHit){
                        itsHit.pedHit();
                    }
                }
            }
            



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
