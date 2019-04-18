using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    private Image fade;

    private void Start()
    {
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<Image>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(mesh.enabled == true)
        {
            mesh.enabled = false;
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<TimeManager>().ExecuteMannequinScare();
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        fade.enabled = true;
        yield return new WaitForSeconds(.5f);
        fade.enabled = false;
        yield return new WaitForSeconds(2.5f);
        fade.enabled = true;
        yield return new WaitForSeconds(1.5f);
        GameObject.FindGameObjectWithTag("Picture").GetComponent<RawImage>().enabled = true;
        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag("Picture").GetComponent<RawImage>().enabled = false;
        Application.Quit();
    }
}
