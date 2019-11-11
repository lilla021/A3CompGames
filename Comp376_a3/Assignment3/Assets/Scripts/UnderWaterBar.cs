﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderWaterBar : MonoBehaviour
{

    public Image Bar;
    public Image Heart1;
    public Image Heart2;
    public float barFiller;
    public float heartFiller1;
    public float heartFiller2;
    private PlayerMovement playerMove;
    void Start()
    {
        barFiller = 50;
        heartFiller1 = 1;
        heartFiller2 = 1;
        playerMove = GetComponent<PlayerMovement>();
    }

    
    void Update()
    {
        barFiller = PlayerStats.currentOxygen / PlayerStats.maxOxygen; //Time.deltaTime * 0.1f;
       
        if (PlayerStats.currentLife == 1)
        {
            heartFiller2 -= Time.deltaTime;
        }
        if (PlayerStats.currentLife == 0)
        {
            heartFiller1 -= Time.deltaTime;
        }
        if (PlayerStats.currentOxygen <= 0.0f)
        {
            if (heartFiller2 != 0)
            heartFiller2 -= Time.deltaTime; 

            heartFiller1 -= Time.deltaTime;

            Invoke("resetGame", 2);
        }

        Bar.fillAmount = barFiller;
        Heart1.fillAmount = heartFiller1;
        Heart2.fillAmount = heartFiller2;

    }
   
    void resetGame()
    {
        playerMove.transform.position = PlayerStats.startingLocation;
        PlayerStats.currentLife = PlayerStats.maxLife;
        PlayerStats.currentOxygen = PlayerStats.maxOxygen;
        PlayerStats.currentLevel = PlayerStats.startingLevel;
        PlayerStats.currentPoints = PlayerStats.startingPoints;
        barFiller = 50;
        heartFiller1 = 1;
        heartFiller2 = 1;
    }
}
