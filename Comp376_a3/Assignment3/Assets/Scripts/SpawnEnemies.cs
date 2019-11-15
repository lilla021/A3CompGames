using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] objects;                // The prefab to be spawned.
    public float spawnTime;            // How long between each spawn.
    public float destroyTime;
    public bool movesRight, movesLeft;
    private Vector3 spawnPosition;
    private Vector3 spawnRotation;
    GameObject s_rightShark, s_leftShark, m_rightShark, m_leftShark, l_rightShark, l_leftShark, octo, spawned;

    // Use this for initialization
    void Start()
    {

        spawnTime = 3.0f;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        s_rightShark = GameObject.Find("s_rightShark");
        s_leftShark = GameObject.Find("s_leftShark");
        m_rightShark = GameObject.Find("m_rightShark");
        m_leftShark = GameObject.Find("m_leftShark");
        l_rightShark = GameObject.Find("l_rightShark");
        l_leftShark = GameObject.Find("l_leftShark");
        //octo = GameObject.Find("Octo");

    }

    void Spawn()
    {

        spawnPosition.x = Random.Range(420, 860);
        spawnPosition.y = Random.Range(2, 32);
        spawnPosition.z = Random.Range(345, 830);

        int rand = UnityEngine.Random.Range(0, objects.Length - 1);
        GameObject enemies = objects[rand];

        Vector3 rot = enemies.transform.rotation.eulerAngles;
        if (GameObject.ReferenceEquals(enemies, s_rightShark))
            rot = new Vector3(rot.x + 180, rot.y, rot.z);
        if (GameObject.ReferenceEquals(enemies, m_rightShark))
            rot = new Vector3(rot.x + 180, rot.y, rot.z);
        if (GameObject.ReferenceEquals(enemies, l_rightShark))
            rot = new Vector3(rot.x + 180, rot.y, rot.z);
        if (GameObject.ReferenceEquals(enemies, s_leftShark))
            rot = new Vector3(rot.x - 180, rot.y, rot.z);
        if (GameObject.ReferenceEquals(enemies, m_leftShark))
            rot = new Vector3(rot.x - 180, rot.y, rot.z);
        if (GameObject.ReferenceEquals(enemies, l_leftShark))
            rot = new Vector3(rot.x - 180, rot.y, rot.z);

        spawned = Instantiate(enemies, spawnPosition, Quaternion.Euler(rot));
        destroyTime = Random.Range(30.0f, 60.0f);
        Destroy(spawned, destroyTime);
    }

  

    private void FaceDirection(Vector3 direction)
    {
        Quaternion rotation3D = direction == Vector3.right ? Quaternion.LookRotation(Vector3.forward) : Quaternion.LookRotation(Vector3.back);
        transform.rotation = rotation3D;

    }
}

