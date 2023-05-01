using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericDeathChecker : MonoBehaviour {

    public bool IsDead = false;
    public Transform BloodProjectorPrefab;
    [HideInInspector()]
    public GameObject world;

    //public Transform SpriteRenderer;
    new public ParticleSystem particleSystem;
    void Awake()
    {
    
    }
    void Start()
    {
        world = WorldGenerator.Singleton.gameObject;
    }
    public IEnumerator Die() {
        transform.SetParent(world.transform);
        //Transform newRenderer = Instantiate<Transform>(SpriteRenderer);
        //newRenderer.rotation *= Quaternion.Euler(0,90,0);
        //newRenderer.SetParent(transform, false);
        gameObject.AddComponent<CapsuleCollider>();
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.constraints = 0;
        rigidbody.angularVelocity = Vector3.forward * 90;
        var main = particleSystem.main;
        main.customSimulationSpace = WorldGenerator.Singleton.transform;
        particleSystem.Play();
        for(int i = 0; i < 8; i++) {
            Instantiate<Transform>(BloodProjectorPrefab, WorldGenerator.Singleton.transform).position = transform.position;
            yield return new WaitForSeconds(.25f);
        }
        //yield return new WaitForSeconds(2);
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
