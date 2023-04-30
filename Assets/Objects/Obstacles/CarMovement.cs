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
        carSpeedMod = Random.Range(1, 30);
        carbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += carSpeedMod * Time.deltaTime * -transform.right;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            carbody.constraints = 0;
        }
    }

}
