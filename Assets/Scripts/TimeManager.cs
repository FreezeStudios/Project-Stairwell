using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private LensDistort lens;

    private void Start()
    {
        //References
        lens = GetComponent<LensDistort>();

        //Starting Timers
        Invoke("ExecuteLensDistort", 120f);
        Invoke("ExecuteLensDistort", 300f);
    }

    private void ExecuteLensDistort()
    {
        lens.Jumpscare();
    }
}
