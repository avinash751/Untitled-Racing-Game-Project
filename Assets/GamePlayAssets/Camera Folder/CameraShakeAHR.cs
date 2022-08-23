using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeAHR : MonoBehaviour
{
    private float time = 0;
    [Range(0, 50)]
    public float frequency;
    [Range(0, 10)]
    public float amplitude;

    public bool cameraShakeEnabled = false;

    public float counter = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        CameraShake();
    }

    public void CameraShake()
    {
        time += Time.deltaTime;
        if (time < counter)
        {
            cameraShakeEnabled = true;
            float x = amplitude * Mathf.Sin(Time.time * frequency);
            float y = amplitude * Mathf.Sin(Time.time * frequency);
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);

            counter = 0;
        }
    }
}
