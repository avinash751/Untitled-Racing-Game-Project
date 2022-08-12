using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvertPWUPController : MonoBehaviour
{
    PlayerInput player;
    public InputActionAsset Normal;
    public InputActionAsset Inverted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<InputActionAsset>();

        if (collision.gameObject.CompareTag("InvrtPOW"))
        {
            player.defaultActionMap = "Inverted";
        }
    }
}
