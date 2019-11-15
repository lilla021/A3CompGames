using UnityEngine;
using System.Collections;

public class Setback : MonoBehaviour
{

    string TheCollider;
    Transform SpawnPoint, Player;

    void Start()
    {
        SpawnPoint = GameObject.Find("SpawnPoint").transform;
        Player = GameObject.Find("FirstPersonPlayer").transform;
    }

    void OnTriggerEnter(Collider other)
    {
        TheCollider = other.tag;
        if (TheCollider == "Player")
        {
            Player.transform.position = SpawnPoint.transform.position;
        }
    }

}