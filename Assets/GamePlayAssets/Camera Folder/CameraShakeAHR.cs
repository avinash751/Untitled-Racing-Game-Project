using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeAHR : MonoBehaviour
{
    public float time;
    [Range(0, 50)]
    public float frequency;
    [Range(0, 10)]
    public float amplitude;

    public bool cameraShakeEnabled;

    public float counter = 3;

    private void Update()
    {
        CameraShake();
    }

    public void CameraShake()
    {
        time += Time.deltaTime;
        if (time < counter && cameraShakeEnabled)
        {
            float x = amplitude * Mathf.Sin(Time.time * frequency);
            float y = amplitude * Mathf.Sin(Time.time * frequency);
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
        }
        else
        {
            EnableCameraShake(false);
        }
    }

    public void EnableCameraShake(bool enable)
    {
        time = 0;

        cameraShakeEnabled = enable;
    }

    public void ChangeCameraShakeValues(float camerafrequency, float cameraamplitude)
    {
        frequency = camerafrequency;
        amplitude = cameraamplitude;
    }
}
