using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carTypes;
    public GameObject carParent;
    public GameObject[] carPosList;
    [Tooltip("Waves of cars per minute"), Range(10, 100)]
    public float SpawnRate = 1;


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



            print("Difficulty: " + difficulty);

            for (int i = 0; i < difficulty; i++)
            {
                int carTypeDecider = UnityEngine.Random.Range(0, carTypes.Length); // Randomly chooses car model
                int laneIndex = UnityEngine.Random.Range(0, availableLanes.Count); // get a random index from the available lanes
                int laneDecider = availableLanes[laneIndex]; // choose the lane at that index
                availableLanes.RemoveAt(laneIndex); // remove the chosen lane from the list
                //print("Lane: " + laneDecider);
                //print("Car Type: " + carTypeDecider);



                GameObject chosenLane = carPosList[laneDecider];
                Vector3 clonedCarPos = new Vector3(chosenLane.transform.position.x, 0, chosenLane.transform.position.z);
                Instantiate(carTypes[carTypeDecider], clonedCarPos, chosenLane.transform.rotation, carParent.transform);
            }

            //GameObject clonedCar = Instantiate(carTypes[carTypeDecider], carPosList[laneDecider].transform.position, carPosList[laneDecider].transform.rotation);

            //Vector3 SpawnPosition = new Vector3(pos0x, 0, pos0z);
            //Instantiate(carTypes[carTypeDecider], SpawnPosition, Quaternion.identity, carParent.transform);


        }
    }
}