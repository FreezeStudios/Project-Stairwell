using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private LensDistort lens;
    private MannequinScare mannequin;

    private void Start()
    {
        //References
        lens = GetComponent<LensDistort>();
        mannequin = GetComponent<MannequinScare>();

        //Starting Timers
        Invoke("ExecuteLensDistort", 120f);
        Invoke("ExecuteLensDistort", 280f);
        Invoke("ExecuteMannequinScare", 375f);
    }

    private void ExecuteLensDistort()
    {
        lens.Jumpscare();
    }

    private void ExecuteMannequinScare()
    {
        mannequin.Jumpscare();
    }
}
