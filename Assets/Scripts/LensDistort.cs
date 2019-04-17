using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LensDistort : MonoBehaviour
{
    [SerializeField] private PostProcessVolume cc;
    [SerializeField] private AudioClip scareSound;

    private LensDistortion lens;

    public void Jumpscare()
    {
        cc.profile.TryGetSettings<LensDistortion>(out lens);
        lens.intensity.Override(-100f);
        AudioManager.instance.PlayAudio(scareSound, 1f);
        StartCoroutine(returnState());
    }

    private IEnumerator returnState()
    {
        yield return new WaitForSeconds(3f);
        cc.profile.TryGetSettings<LensDistortion>(out lens);
        lens.intensity.Override(0f);
    }
}
