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
        Invoke("ExecuteLensDistort", 110f);
        Invoke("ExecuteLensDistort", 210f);
        Invoke("ExecuteMannequinScare", 310f);
    }

    public void ExecuteLensDistort()
    {
        lens.Jumpscare();
    }

    public void ExecuteMannequinScare()
    {
        mannequin.Jumpscare();
    }
}
