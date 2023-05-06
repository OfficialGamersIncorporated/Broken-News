using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
    public float delayBeforeFollowing = .333f;
    public static float followSpeed = 8f;  // the speed at which to follow
    float tickSpawned;

    public AudioSource BarkingSound;
    private GameObject player;
    Animator animator;
    GenericDeathChecker deathChecker;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start() {
        deathChecker = GetComponent<GenericDeathChecker>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        player = DeathChecker.Singleton.gameObject;
        //rb.constraints = RigidbodyConstraints.FreezeRotation; // Freeze rotation so the follower doesn't rotate // this can be done in the editor instead.
        tickSpawned = Time.time;
    }

    void FacePlayer() {
        //transform.LookAt(Vector3.ProjectOnPlane(player.transform.position, Vector3.up) + Vector3.up * transform.position.y);
        if(player.transform.position.x > transform.position.x) {
            transform.forward = Vector3.right;
        } else {
            transform.forward = -Vector3.right;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        // wait a moment after spawning before chasing the player.
        if(Time.time - tickSpawned < delayBeforeFollowing) {
            FacePlayer();
            return;
        }

        if(!deathChecker.IsDead) {
            // Calculate the direction to the target object
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Calculate the velocity required to reach the target object
            Vector3 targetVelocity = direction * followSpeed;

            // Calculate the force required to change the velocity
            Vector3 force = (targetVelocity - rb.velocity) * rb.mass / Time.fixedDeltaTime;

            // Apply the force to the rigidbody
            rb.AddForce(force);

            FacePlayer();


            /*
            // calculate the direction to move towards
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // move towards the target position
            rb.MovePosition(transform.position + direction * followSpeed * Time.fixedDeltaTime);*/
        } else {
            gameObject.tag = "Untagged";
            animator.enabled = false;
            if(BarkingSound) BarkingSound.enabled = false;
        }
    }
}
