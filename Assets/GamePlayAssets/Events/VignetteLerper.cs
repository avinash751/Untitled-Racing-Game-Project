using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;



public class VignetteLerper : MonoBehaviour
{
    public Volume PostProcess;
    public Vignette P_Vignette;
    [SerializeField] float Duration;
    [SerializeField] float VignneteIntensity;
    [SerializeField] float TimeElapsed;
    [SerializeField] bool StartLerping;

    void Start()
    {
        PostProcess.profile.TryGet(out P_Vignette);
    }
    void Update()
    {
        LerpVignnette();
    }

    void LerpVignnette()
    {
        if (StartLerping && TimeElapsed < Duration)
        {
            TimeElapsed += Time.deltaTime;
            P_Vignette.intensity.value = Mathf.Lerp(P_Vignette.intensity.value, VignneteIntensity, TimeElapsed / 1);
        }
        else if (StartLerping && P_Vignette.intensity.value == VignneteIntensity )
        {
            EnableLerping(false);
            SetElapsedTimeTOZero();
            Debug.Log("lerping disabled");
        }

        if(!StartLerping && TimeElapsed < 1 && P_Vignette.intensity.value != 0)
        {
            TimeElapsed += Time.deltaTime;
            P_Vignette.intensity.value = Mathf.Lerp(P_Vignette.intensity.value, 0, TimeElapsed / 1);
        }
        else if(!StartLerping && TimeElapsed ==1)
        {
            SetElapsedTimeTOZero();
        }
    }
    public void EnableLerping(bool enable)
    {
        StartLerping = enable;
    }
    public void SetElapsedTimeTOZero()
    {
        TimeElapsed = 0;
    }
}
