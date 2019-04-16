using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStairs : MonoBehaviour
{
    [SerializeField] private GameObject stairsPrefab;
    private Transform stairwell;

    private void Start()
    {
        stairwell = GameObject.FindGameObjectWithTag("Stairwell").GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player")
        {
            Quaternion rot = Quaternion.Euler(0, 0, 0);
            int stairwellChildCount = stairwell.childCount - 1;
            Vector3 pos = stairwell.GetChild(stairwellChildCount).transform.position;
            Vector3 modPos = new Vector3(pos.x,pos.y -5f, pos.z);
            GameObject go = Instantiate(stairsPrefab, modPos, rot,stairwell);
            go.name = "Full_Stairs " + stairwellChildCount.ToString();
            Destroy(gameObject);
        }
    }
}
