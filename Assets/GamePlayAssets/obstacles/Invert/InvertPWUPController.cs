using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvertPWUPController : MonoBehaviour
{
    PlayerInput playercontrol;
    bool controlinvert;
    public float Time;
    
    public bool inverted;

    //Andrew's Code
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
      
        if (collision.gameObject.CompareTag("Player") && !collision.gameObject.GetComponent<Respawn>().ignoreObstacleCollision &&!inverted)
        {
            playercontrol = collision.gameObject.GetComponent<PlayerInput>();
            playercontrol.actions.FindActionMap("Inverted").Enable();
            playercontrol.actions.FindActionMap("Normal").Disable();
            Debug.Log("inverted");
            Invoke(nameof(disableinvertcontrols), Time); // humaid's code
            Invoke(nameof(SetInvertedBool), 0.02f); // avinash code
            GetComponent<SpawnParticlesOnCollsion>().SpawnParticleSystemThenDestroy(collision.transform);
            GetComponent<SpawnParticlesOnCollsion>().DoExtraThingsOnCollision.Invoke();

        }
   

    }
    // humaid's code
    void disableinvertcontrols()
    {
        playercontrol.actions.FindActionMap("Inverted").Disable();
        playercontrol.actions.FindActionMap("Normal").Enable();
        inverted = false;
        Debug.Log("controls back to normal");
    }

  


    
   void SetInvertedBool()
    {
        inverted = true;
    }


}
