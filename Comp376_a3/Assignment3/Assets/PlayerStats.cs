using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float currentOxygen { get; set; } = 50.0f;
    public static float maxOxygen { get; set; } = 50.0f;
    public static int currentLife { get; set; } = 2;
    public static int maxLife { get; set; } = 2;
    public static int currentLevel { get; set; } = 0;
    public static int startingLevel { get; set; } = 0;
    public static int currentPoints { get; set; } = 0;
    public static int startingPoints { get; set; } = 0;
    public static Vector3 startingLocation{ get; set; } = new Vector3(854.25f, 41.82f, 411.0f);
    
}
