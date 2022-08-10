using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvertPWUPController : MonoBehaviour
{
    PlayerInput player;
    ControllerInputSystem controller;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<PlayerInput>();
        controller.Player_1.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InvrtPOW"))
        {
            
        }
    }
}
