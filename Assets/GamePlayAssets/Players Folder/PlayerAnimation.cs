using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
     public Animator PlayerAnimator;
     public Controls PlayerControls;
    public string jumpAnim;
    public string runAnim;
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControls.Grounded && FindObjectOfType<GameStateMachine>().gamestate == GameStateMachine.GameState.Current)
        {
            PlayerAnimator.enabled = true;
            PlayerAnimator.Play(runAnim);
           
        }
        else if(!PlayerControls.Grounded && FindObjectOfType<GameStateMachine>().gamestate == GameStateMachine.GameState.Current)
        {
            PlayerAnimator.enabled = true;
            PlayerAnimator.Play(jumpAnim,-1,0f);
        }

    }
}
