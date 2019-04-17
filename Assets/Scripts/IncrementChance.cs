using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrementChance : MonoBehaviour
{
    private int bloodSpawnChance = 0;
    private void Start()
    {
        bloodSpawnChance = PlayerPrefs.GetInt("BloodSpawnChance");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            bloodSpawnChance = Random.Range(bloodSpawnChance+3, bloodSpawnChance+10);
            PlayerPrefs.SetInt("BloodSpawnChance", bloodSpawnChance);
        }
    }
}
