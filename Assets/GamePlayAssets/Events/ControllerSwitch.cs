using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ControllerSwitch : MonoBehaviour
{
    PlayerInput controlswitch;
    [SerializeField] InputActionAsset LeftSide;
    [SerializeField] InputActionAsset RightSide;
    [SerializeField] Controls[] AllPlayers;
    [SerializeField] float time;
    [Header("Do more on collsion, if needed")]
    public UnityEvent PlayEventOnCollsion;
    public bool switched;

    public CameraShakeAHR camerashake;


    private void Awake()
    {
        AllPlayers = FindObjectsOfType<Controls>();
    }

    //Andrew & Avinash Code
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && !switched)
        {
            camerashake.SetCameraShakeValues(75, 0.2f, 0.5f);

            camerashake.EnableCamersShake(true);
           

            switched = true;
            controlswitch = collision.gameObject.GetComponent<PlayerInput>();
            AllPlayers[0].GetComponent<PlayerInput>().actions = RightSide;
            AllPlayers[1].GetComponent<PlayerInput>().actions = LeftSide;
            Invoke(nameof(SwitchBackToNormalControls), time);
            PlayEventOnCollsion.Invoke();
            Debug.Log("switch side");
        }
    }
    void SwitchBackToNormalControls()
    {
        switched = false;
        AllPlayers[0].GetComponent<PlayerInput>().actions = LeftSide;
        AllPlayers[1].GetComponent<PlayerInput>().actions = RightSide;
        Debug.Log("switched back");
    }
}
