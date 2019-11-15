using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    public GameObject[] objects;                // The prefab to be spawned.
    public float spawnTime;            // How long between each spawn.
    public float destroyTime;
    private Vector3 spawnPosition;
    private Vector3 spawnRotation;
    GameObject bar, coins, diamond, spawned;

    // Use this for initialization
    void Start()
    {
        
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        spawnTime = 1.0f;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        bar = GameObject.Find("Bar");
        coins = GameObject.Find("Coins");
        diamond = GameObject.Find("Diamond");
    }

    void Spawn()
    {
        
        spawnPosition.x = Random.Range(420, 860);
        spawnPosition.y = 0.25f;
        spawnPosition.z = Random.Range(345, 830);

        GameObject gold = objects[UnityEngine.Random.Range(0, objects.Length - 1)];

        Vector3 rot = gold.transform.rotation.eulerAngles;
        if (GameObject.ReferenceEquals(gold, coins))
            rot = new Vector3(rot.x + 180, rot.y, rot.z);
        if(GameObject.ReferenceEquals(gold, bar))
            rot = new Vector3(rot.x, rot.y, rot.z);
        if(GameObject.ReferenceEquals(gold, diamond))
            rot = new Vector3(rot.x, rot.y, rot.z);
        spawned = Instantiate(gold, spawnPosition, Quaternion.Euler(rot));

        destroyTime = Random.Range(30.0f, 60.0f);
        Destroy(spawned, destroyTime);
    }
}
