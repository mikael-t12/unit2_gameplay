using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    public GameObject[] animalPrefabs;

    private float startDelay = 2;
    private float spawnInterval = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        //Call the random spawn function in a loop
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Function for spawning the animals
    void SpawnRandomAnimal()
    {
        //randomize the spawn range
        Vector3 spawnPositon = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int AnimalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[AnimalIndex], spawnPositon, animalPrefabs[AnimalIndex].transform.rotation);
    }
}
