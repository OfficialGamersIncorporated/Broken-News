using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private GameObject player;
    public float followSpeed = 5f;  // the speed at which to follow
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = DeathChecker.Singleton.gameObject;
                rb.constraints = RigidbodyConstraints.FreezeRotation; // Freeze rotation so the follower doesn't rotate
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GetComponent<GenericDeathChecker>().IsDead)
        {
            // Calculate the direction to the target object
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Calculate the velocity required to reach the target object
            Vector3 targetVelocity = direction * followSpeed;

            // Calculate the force required to change the velocity
            Vector3 force = (targetVelocity - rb.velocity) * rb.mass / Time.fixedDeltaTime;

            // Apply the force to the rigidbody
            rb.AddForce(force);


            /*
            // calculate the direction to move towards
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // move towards the target position
            rb.MovePosition(transform.position + direction * followSpeed * Time.fixedDeltaTime);*/
        }
        else
        {
            gameObject.tag = "Untagged";
        }
    }
}
