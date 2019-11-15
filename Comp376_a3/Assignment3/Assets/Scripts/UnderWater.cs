using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{

    public float waterLevel;
    public float groundLevel;
    private bool isUnderWater;
    private Color normalColor;
    private Color underWaterColor;
    private PlayerMovement playerMove;
       
    void Start()
    {
        normalColor = new Color(0.5f, 0.5f, 0.5f);
        underWaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
        playerMove = GetComponent<PlayerMovement>();
       
    }

    void Update()
    {
        if (transform.position.y < waterLevel)
            playerMove.isSwimming = true;
        else
            playerMove.isSwimming = false;

        if ((transform.position.y < waterLevel - 1.25) != isUnderWater)
        {
            isUnderWater = transform.position.y < waterLevel - 1.25;
           
            if (isUnderWater) setUnderWater();
            if (!isUnderWater) setNormal();
        }
    }

    void setUnderWater()
    {
        RenderSettings.fogColor = underWaterColor;
        RenderSettings.fogDensity = 0.02f;
        playerMove.gravity = -3.0f;
        playerMove.speed = 4.0f;
        playerMove.jumpHeight = 3.0f;
    }

    void setNormal()
    {
        RenderSettings.fogColor = normalColor;
        RenderSettings.fogDensity = 0.002f;
        playerMove.gravity = -9.81f;
        playerMove.speed = 12.0f;
        playerMove.jumpHeight = 4.0f;
    }
 
}
