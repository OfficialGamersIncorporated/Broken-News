using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float carSpeedMod;
    public Vector2 SpeedRange_SameDir = new Vector2(10, 20);
    public Vector2 SpeedRange_Oncoming = new Vector2(0, 15);
    public float HitAndRunRarity = 30;
    public float HitAndRunSpeedBoost = 15;
    Rigidbody carbody;
    bool IsHitAndRun = false;

    
    // Start is called before the first frame update
    void Start()
    {
        if (Vector3.Dot(transform.forward, Vector3.right) > 0) {
            carSpeedMod = WorldGenerator.Singleton.Speed + SpeedRange_SameDir.x + Mathf.Pow(Random.Range(0, SpeedRange_SameDir.y) / 10, 2); //Random.Range(15, 20);
        } else {
            carSpeedMod = SpeedRange_Oncoming.x + Mathf.Pow(Random.Range(0, SpeedRange_Oncoming.y) / 10, 2); //Random.Range(5, 20);
        }
        carbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += carSpeedMod * Time.deltaTime * transform.forward;
        if (carSpeedMod > 0)
            carbody.velocity = carSpeedMod * transform.forward;

        if (transform.position.y < -10) {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            carbody.constraints = 0;
        }
        if(IsHitAndRun) return;
        else if(collision.gameObject.CompareTag("Car")) {
            if(Random.Range(1, HitAndRunRarity) <= 1) {
                carSpeedMod = WorldGenerator.Singleton.Speed + HitAndRunSpeedBoost;
                IsHitAndRun = true;
                return;
            }
            carbody.constraints = 0;
            carSpeedMod = 0;
        }
    }

}
