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

    Transform startposition;

    public float counter ;
    // Start is called before the first frame update
    void Start()
    {
        startposition = gameObject.transform;
    }

    private void Update()
    {
        CameraShake();
        
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
            EnableCamersShake(false);
        }
    }

    public void EnableCamersShake(bool enable)
    {
        gameObject.transform.position = new Vector3(startposition.position.x, startposition.position.y, gameObject.transform.position.z);  
        cameraShakeEnabled = enable;
    }

    public void SetCameraShakeValues(float Frequency,float Amplitude, float duration)

    {
        counter = duration;
        amplitude = Amplitude;
        frequency = Frequency;
    }
}
