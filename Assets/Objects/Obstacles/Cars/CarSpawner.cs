using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carTypesNormal;
    public GameObject[] carTypesRare;
    public GameObject carParent;
    public GameObject[] carPosList;
    [Tooltip("Waves of cars per minute"), Range(1, 100)]
    public float SpawnRate = 1;
    [Tooltip("Rare type chance"), Range(1, 100)]
    public int rarityChance = 10;

    private IEnumerator Start()
    {
        carPosList = new GameObject[4];
        for (int i = 0; i < carPosList.Length; i++)
        {
            carPosList[i] = GameObject.Find("pos" + (i));
        }

        while (true)
        {
            yield return new WaitForSeconds((1 / SpawnRate) * 60); // Waits one second

            int difficulty = UnityEngine.Random.Range(1, 4); // Randomly chooses difficulty
            // List<int> availableLanes = new() { 0, 1, 2, 3 }; // create a list of available lanes

            List<int> availableLanes = new List<int>
            {
                0,
                1,
                2,
                3
            };

            for (int i = 0; i < difficulty; i++)
            {
                int rarityDecider = UnityEngine.Random.Range(0, rarityChance);
                //print("Rarity roll: " + rarityDecider);
                if(rarityDecider > 1) // < (rarityChance - 1) // chance for normal car type
                {
                    int carTypeDecider = UnityEngine.Random.Range(0, carTypesNormal.Length); // Randomly chooses car model
                    int laneIndex = UnityEngine.Random.Range(0, availableLanes.Count); // get a random index from the available lanes
                    int laneDecider = availableLanes[laneIndex]; // choose the lane at that index
                    availableLanes.RemoveAt(laneIndex); // remove the chosen lane from the list
                    GameObject chosenLane = carPosList[laneDecider];
                    Vector3 clonedCarPos = new Vector3(chosenLane.transform.position.x, 0, chosenLane.transform.position.z);
                    Instantiate(carTypesNormal[carTypeDecider], clonedCarPos, chosenLane.transform.rotation, carParent.transform);
                }
                else // chance for rare car type
                {
                    int carTypeDecider = UnityEngine.Random.Range(0, carTypesRare.Length); // Randomly chooses car model
                    int laneIndex = UnityEngine.Random.Range(0, availableLanes.Count); // get a random index from the available lanes
                    int laneDecider = availableLanes[laneIndex]; // choose the lane at that index
                    availableLanes.RemoveAt(laneIndex); // remove the chosen lane from the list
                    GameObject chosenLane = carPosList[laneDecider];
                    Vector3 clonedCarPos = new Vector3(chosenLane.transform.position.x, 0, chosenLane.transform.position.z);
                    Instantiate(carTypesRare[carTypeDecider], clonedCarPos, chosenLane.transform.rotation, carParent.transform);
                }

            }
        }
    }
}