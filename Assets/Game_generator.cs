using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_generator : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject platformPrefab2;

    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = 3f;
    public float maxY = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            if(Random.Range(1,8) == 1 && i <= numberOfPlatforms) Instantiate(platformPrefab2, spawnPosition, Quaternion.identity);
            else Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
