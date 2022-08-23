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
    public string Button1;
    public string Button2;



    bool EnableInput;

    [SerializeField] Controls PlayerControl;
    // Start is called before the first frame update

    private void Awake()
    {
       PlayerControl= GetComponent<Controls>();
        EnablingInput(false);
        ChnageInput();
        EnablingInput(true);
        AssigningFunctionToInputAction();
        GetComponent<PlayerInput>().actions = null;
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

    void ChnageInput()
    {

        JumpAction.ChangeBinding(0).WithPath("<Gamepad>/"+ Button1);
        DashAction.ChangeBinding(0).WithPath("<Gamepad>/"+ Button2);
        // Change path to space key.
    }
}
