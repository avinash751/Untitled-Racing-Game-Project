using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerSwitch : MonoBehaviour
{
    PlayerInput controlswitch;
    [SerializeField] InputActionAsset LeftSide;
    [SerializeField] InputActionAsset RightSide;
    [SerializeField] Controls[] AllPlayers;
    [SerializeField] float time;


    private void Awake()
    {
        AllPlayers = FindObjectsOfType<Controls>();
    }

    //Andrew & Avinash Code
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            controlswitch = collision.gameObject.GetComponent<PlayerInput>();
            AllPlayers[0].GetComponent<PlayerInput>().actions = RightSide;
            AllPlayers[1].GetComponent<PlayerInput>().actions = LeftSide;
            Invoke(nameof(SwitchBackToNormalControls), time);
            Debug.Log("switch side");
        }
    }
    void SwitchBackToNormalControls()
    {
        AllPlayers[0].GetComponent<PlayerInput>().actions = LeftSide;
        AllPlayers[1].GetComponent<PlayerInput>().actions = RightSide;
        Debug.Log("switched back");
    }
}
