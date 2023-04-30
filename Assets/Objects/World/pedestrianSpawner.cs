using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestrianSpawner : MonoBehaviour
{
    public GameObject[] pedestrianTypes;
    public GameObject pedestrianParent;
    public GameObject[] pedestrianPosList;
    [Tooltip("Amount of Pedestrians Spawned per Minute"), Range(10, 100)]
    public float PedestrianSpawnRateMult = 1;


    // Start is called before the first frame update
    private IEnumerator Start()
    {
        pedestrianPosList = new GameObject[4];
        for (int i = 0; i < pedestrianPosList.Length; i++)
        {
            pedestrianPosList[i] = GameObject.Find("pedPos" + (i));
        }

        while (true)
        {
            yield return new WaitForSeconds((1 / (1 * PedestrianSpawnRateMult)) * 60);


            int pedestrianTypeDecider = UnityEngine.Random.Range(0, pedestrianTypes.Length); // Randomly chooses pedestrian type
            int pedestrianSpawnDecider = UnityEngine.Random.Range(0, pedestrianPosList.Length); // Randomly chooses spawn point
            GameObject chosenPedSpawn = pedestrianPosList[pedestrianSpawnDecider];
            Vector3 clonedPedestrianPos = new Vector3(chosenPedSpawn.transform.position.x, 0, chosenPedSpawn.transform.position.z);
            Instantiate(pedestrianTypes[pedestrianTypeDecider], clonedPedestrianPos, chosenPedSpawn.transform.rotation, pedestrianParent.transform);
        }




        // Update is called once per frame
        /*void Update()
        {

        }*/
    }
}
