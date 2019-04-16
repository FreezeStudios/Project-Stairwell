using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Light flashLight;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private float smooth = 3;
    private bool isOn = true;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetTransform.position, smooth * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetTransform.rotation, smooth * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            flashLight.enabled = isOn;
            audioS.Play();
        }
    }
}
