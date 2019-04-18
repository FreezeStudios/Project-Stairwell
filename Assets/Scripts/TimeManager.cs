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
        Invoke("ExecuteLensDistort", 130f);
        Invoke("ExecuteLensDistort", 230f);
        Invoke("ExecuteMannequinScare", 330f);
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
