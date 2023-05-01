using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float carSpeedMod;
    public Vector2 SpeedRange_SameDir = new Vector2(10, 20);
    public Vector2 SpeedRange_Oncoming = new Vector2(0, 15);
    public float HitAndRunRarity = 20;
    public float HitAndRunSpeedBoost = 20;
    public Transform AngrySpeachBubblePrefab;
    Transform angrySpeachBubble;
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

    void EnableAngrySpeachBubble() {
        if(!angrySpeachBubble) {
            angrySpeachBubble = Instantiate<Transform>(AngrySpeachBubblePrefab, transform);
            angrySpeachBubble.localPosition = Vector3.up * 2.5f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // if we hit the pitBull always run it the hell over // car should still get derailed though and fly into oncoming traffic.
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.name == "PitBull")
        {
            carbody.constraints = 0;
            EnableAngrySpeachBubble();
        }

        if(IsHitAndRun) return;

        if(collision.gameObject.CompareTag("Car")) {
            EnableAngrySpeachBubble();
            if(Random.Range(0, HitAndRunRarity) <= 1) {
                print("HIT AND RUUUUN");
                carSpeedMod = WorldGenerator.Singleton.Speed + HitAndRunSpeedBoost;
                IsHitAndRun = true;
                return;
            }
            carbody.constraints = 0;
            carSpeedMod = 0;
        }
    }

}
