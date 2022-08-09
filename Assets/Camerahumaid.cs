using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerahumaid : MonoBehaviour
{

    public GameObject firsttouchCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (firsttouchCam.transform.position.x, transform.position.y, transform.position.z);
    }
}
