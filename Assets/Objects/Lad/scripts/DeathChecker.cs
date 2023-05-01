using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathChecker : MonoBehaviour {

    public bool IsDead = false;
    public Transform BloodProjectorPrefab;
    public ParticleSystem PaperParticleEmitter;
    public static DeathChecker Singleton;
    AudioSource deathSound;
    Animator animator;

    //public Transform SpriteRenderer;
    new public ParticleSystem particleSystem;
    void Awake()
    {
        Singleton = this;
        deathSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    public IEnumerator Die() {
        animator.SetTrigger("Hit");
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        //GetComponent<Animator>().enabled = false;
        //Transform newRenderer = Instantiate<Transform>(SpriteRenderer);
        //newRenderer.rotation *= Quaternion.Euler(0,90,0);
        //newRenderer.SetParent(transform, false);
        gameObject.GetComponent<CapsuleCollider>().height = 1;
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.angularVelocity = Vector3.forward * 90;
        var main = particleSystem.main;
        main.customSimulationSpace = WorldGenerator.Singleton.transform;
        transform.parent = WorldGenerator.Singleton.transform;
        particleSystem.Play();
        var UnityBullshit = PaperParticleEmitter.main;
        UnityBullshit.customSimulationSpace = WorldGenerator.Singleton.transform;
        var moreUnityBullshit = PaperParticleEmitter.subEmitters.GetSubEmitterSystem(0).main;
        moreUnityBullshit.customSimulationSpace = WorldGenerator.Singleton.transform;
        if(deathSound) deathSound.Play();
        PaperParticleEmitter.Emit(25);
        for(int i = 0; i < 8; i++) {
            Instantiate<Transform>(BloodProjectorPrefab, WorldGenerator.Singleton.transform).position = transform.position;
            yield return new WaitForSeconds(.25f);
        }
        float startTick = Time.time;
        while(Time.time - startTick < 2) {
            //rigidbody.velocity = -Vector3.up * 5;
            if (rigidbody.velocity.magnitude < 3) {
                animator.SetBool("Hit_StoppedMoving", true);
                rigidbody.isKinematic = true;
                transform.rotation = Quaternion.identity;
                transform.position += Vector3.up * 1;
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("DeadMenu");
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Car")) {
            if(!IsDead) {
                IsDead = true;
                StartCoroutine(Die());
            }
        }
    }

}
