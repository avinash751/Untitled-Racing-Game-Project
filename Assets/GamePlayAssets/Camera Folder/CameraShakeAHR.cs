using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeAHR : MonoBehaviour
{
    private float time;
    [Range(0, 50)]
    public float frequency;
    [Range(0, 1)]
    public float amplitude;

    public bool cameraShakeEnabled = false;
    Vector3 startPosition;
    public float counter ;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        CameraShake();
    }

    void CameraShake()
    {
       
        if (time < counter && cameraShakeEnabled)
        {
            time += Time.deltaTime;
            cameraShakeEnabled = true;
            float Xshake = amplitude * Mathf.Sin(Time.time * frequency);
            float Yshake = amplitude * Mathf.Sin(Time.time * frequency);
            transform.position = new Vector3(transform.position.x+Xshake,Yshake, transform.position.z); // adding current position of x and xshake becasue camera  is moving at x axis every frame
        }
        else
        {
            EnableCamersShake(false);
        }
    }

    public void EnableCamersShake(bool enable)
    {
        time = 0;
        cameraShakeEnabled = enable;
        transform.position = new Vector3(transform.position.x, startPosition.y, startPosition.z);
    }

    public void SetCameraShakeValues(float Frequency,float Amplitude,float duration)
    {
        amplitude = Amplitude;
        frequency = Frequency;
        counter = duration;
    }
}
