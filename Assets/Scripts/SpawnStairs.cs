using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStairs : MonoBehaviour
{
    [SerializeField] private GameObject stairsPrefab;
    private Transform stairwell;
    private int bloodSpawnChance = 0;
    private float bossPawnChance = 0;

    private void Start()
    {
        stairwell = GameObject.FindGameObjectWithTag("Stairwell").GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            //Spawning
            Quaternion rot = Quaternion.Euler(0, 0, 0);
            int stairwellChildCount = stairwell.childCount - 1;
            Vector3 pos = stairwell.GetChild(stairwellChildCount).transform.position;
            Vector3 modPos = new Vector3(pos.x,pos.y -5f, pos.z);
            GameObject go = Instantiate(stairsPrefab, modPos, rot,stairwell);
            go.name = "Full_Stairs " + stairwellChildCount.ToString();
            HandleBlood(go);//Handle Blood Chances
            HandleBoss(go);//Handle Boss Chances
            //Destroy
            Destroy(gameObject);
        }
    }

    private void HandleBlood(GameObject go)
    {
        //Increment Chances
        bloodSpawnChance = PlayerPrefs.GetInt("BloodSpawnChance");
        bloodSpawnChance += Random.Range(3, 10);// 3 - 9
        PlayerPrefs.SetInt("BloodSpawnChance", bloodSpawnChance);
        //Chances
        int spawnBlood = Random.Range(bloodSpawnChance, 101);//Blood
        if (spawnBlood >= 100)
        {
            spawnBlood = 0;
            PlayerPrefs.SetInt("BloodSpawnChance", 0);
            go.transform.GetChild(go.transform.childCount - 1).GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            go.transform.GetChild(go.transform.childCount - 1).GetComponent<MeshRenderer>().enabled = false;
        }
    }


    private void HandleBoss(GameObject go)
    {
        //Increment Chances
        bossPawnChance = PlayerPrefs.GetInt("BossPawnChance");
        bossPawnChance += Random.Range(1f, 2.5f);// 1f - 2.4f
        PlayerPrefs.SetFloat("BossPawnChance", bossPawnChance);
        //Chances
        float spawnBoss = Random.Range(bloodSpawnChance, 101);//Boss
        if (spawnBoss >= 100)
        {
            spawnBoss = 0;
            PlayerPrefs.SetFloat("BossPawnChance", 0);
            go.transform.GetChild(go.transform.childCount - 2).GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            go.transform.GetChild(go.transform.childCount - 2).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
