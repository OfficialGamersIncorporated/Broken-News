using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperLaunch : MonoBehaviour
{
    //private Vector3 hitPoint;
    public GameObject paper;
    public float angle = 45f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~LayerMask.GetMask("SpeedUpCollider")))
            {
                Vector3 hitPoint = hit.point;
                hitPoint = Vector3.ProjectOnPlane(hitPoint, Vector3.up);
                float distance = Vector3.Distance(transform.position, hitPoint);
                float gravity = Physics.gravity.y;

                // Calculate the initial velocity
                float initialVelocity = Mathf.Sqrt(-2 * gravity * (distance/2) / (Mathf.Sin(2 * angle * Mathf.Deg2Rad)));

                // Spawn the prefab
                GameObject spawnedObject = Instantiate(paper, transform.position, Quaternion.identity);

                // Add the rigidbody component
                Rigidbody rb = spawnedObject.AddComponent<Rigidbody>();

                // Calculate the direction and apply the force
                Vector3 direction = hitPoint - transform.position;
                direction.y = direction.magnitude * Mathf.Tan(angle * Mathf.Deg2Rad);
                direction = direction.normalized;
                rb.velocity = (direction * initialVelocity);//, ForceMode.VelocityChange);
            }
        }
    }
}
