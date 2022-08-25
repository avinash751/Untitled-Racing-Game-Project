using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeAHR : MonoBehaviour
{
    private float time;
    [Range(0, 50)]
    public float frequency;
    [Range(0, 10)]
    public float amplitude;

    public bool cameraShakeEnabled = false;

    public float counter ;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
       
    }

    void CameraShake()
    {
        time += Time.deltaTime;
        if (time < counter && cameraShakeEnabled)
        {
            cameraShakeEnabled = true;
            float x = amplitude * Mathf.Sin(Time.time * frequency);
            float y = amplitude * Mathf.Sin(Time.time * frequency);
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
        }
        else
        {
            cameraShakeEnabled = false;
        }
    }

    public void EnableCamersShake(bool enable)
    {
        cameraShakeEnabled = enable;
    }

    public void SetCameraShakeValues(float Frequency,float Amplitude)
    {
        amplitude = Amplitude;
        frequency = Frequency;
    }
}
