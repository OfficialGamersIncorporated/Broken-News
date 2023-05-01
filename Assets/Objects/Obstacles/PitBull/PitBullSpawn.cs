using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitBullSpawn : MonoBehaviour
{
    private WorldGenerator wg;
    private bool lastIsPositive;

    private bool hasAlreadyAttempted()
    {
        Vector3 doorPos = transform.position;
        Vector3 doorWorldPos = wg.transform.InverseTransformPoint(doorPos);

        return GameplayManager.Singleton.AlreadyPassedDoors.Contains(doorWorldPos);
    }
    private void AttemptPitbullSpawn()
    {
        if(!hasAlreadyAttempted())
        {

            Vector3 doorPos = transform.position;
            Vector3 doorWorldPos = wg.transform.InverseTransformPoint(doorPos);
            GameplayManager.Singleton.AlreadyPassedDoors.Add(doorWorldPos);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        wg = WorldGenerator.Singleton;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= 0 && lastIsPositive)
        {
            print("SPAWN TIME");
            lastIsPositive = false;
        }
        lastIsPositive = transform.position.x > 0;
    }
}
