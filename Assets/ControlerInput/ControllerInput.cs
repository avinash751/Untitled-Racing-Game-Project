using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Controls))]
public class ControllerInput : MonoBehaviour
{
    [Header("Player  Input")]
    public InputAction JumpAction;
    public InputAction DashAction;



    bool EnableInput;

    [SerializeField] Controls PlayerControl;
    // Start is called before the first frame update

    private void Awake()
    {
       PlayerControl= GetComponent<Controls>();
        EnablingInput(false);
 
        EnablingInput(true);
        AssigningFunctionToInputAction();
    }
    void Start()
    {
        
    }
    void AssigningFunctionToInputAction()
    {

        JumpAction.performed+=ctx => PlayerControl.JumpImplementation();
        DashAction.performed+= ctx => PlayerControl.DashDownImplementation();

    }
    void EnablingInput(bool InputEnable)
    {
        EnableInput=InputEnable;
        if(EnableInput)
        {
            JumpAction.Enable();
            DashAction.Enable();
        }
        else
        {
            JumpAction.Disable();
            DashAction.Disable();
        }
    }
 
}
