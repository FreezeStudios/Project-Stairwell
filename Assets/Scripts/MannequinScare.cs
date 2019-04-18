using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinScare : MonoBehaviour
{
    [SerializeField] private GameObject larry;
    [SerializeField] private AudioClip scareSound;
    public void Jumpscare()
    {
        larry.SetActive(true);
        AudioManager.instance.PlayAudio(scareSound, 1.0f);
        StartCoroutine(ReturnState());
    }

    private IEnumerator ReturnState()
    {
        yield return new WaitForSeconds(2.5f);
        larry.SetActive(false);
    }
}
