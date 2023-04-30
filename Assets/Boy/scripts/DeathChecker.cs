using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathChecker : MonoBehaviour {

    public bool IsDead = false;
    //public Transform SpriteRenderer;

    public IEnumerator Die() {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GetComponent<Animator>().enabled = false;
        //Transform newRenderer = Instantiate<Transform>(SpriteRenderer);
        //newRenderer.rotation *= Quaternion.Euler(0,90,0);
        //newRenderer.SetParent(transform, false);
        gameObject.AddComponent<CapsuleCollider>();
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.angularVelocity = Vector3.forward * 90;
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
