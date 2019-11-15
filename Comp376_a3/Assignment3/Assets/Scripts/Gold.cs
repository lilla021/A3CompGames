using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("FirstPersonPlayer"))
        {
            if (this.gameObject.CompareTag("Bar"))
            {
                PlayerStats.goldValue = 3;
                PlayerStats.weightSpeed = 1.5f;
                Debug.Log("Picked up bar!");
            }
            if (this.gameObject.CompareTag("Diamond"))
            {
                PlayerStats.goldValue = 2;
                PlayerStats.weightSpeed = 1.0f;
                Debug.Log("Picked up diamond!");
            }
            if (this.gameObject.CompareTag("Coins"))
            {
                PlayerStats.goldValue = 1;
                PlayerStats.weightSpeed = 0.5f;
                Debug.Log("Picked up coins!");
            }
         
            PlayerStats.hasGold = true;
            Destroy(this.gameObject);

        }
    }
}
