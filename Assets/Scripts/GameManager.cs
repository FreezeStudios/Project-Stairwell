using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("BloodSpawnChance", 0);
    }

    private void Update()
    {
        
    }
}
