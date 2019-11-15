using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("FirstPersonPlayer") && PlayerStats.hasGold == true)
        {
            Debug.Log("Dropped gold onto boat!");

            PlayerStats.currentPoints += PlayerStats.goldValue;

            PlayerStats.hasGold = false;
            PlayerStats.goldValue = 0;
            PlayerStats.weightSpeed = 0.0f;

        }
    }
}
