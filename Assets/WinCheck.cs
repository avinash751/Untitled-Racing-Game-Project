using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    public GameStateMachine manager;
    public GameObject PlayerRedWin;
    public GameObject PlayerWhiteWin;
    public GameObject PlayerRed;
    public GameObject PlayerWhite;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        manager.GameOver();
        if (collision.gameObject== PlayerWhite)
        {
            PlayerWhiteWin.SetActive(true);
            Debug.Log("player won");
        }
        else if (collision.gameObject== PlayerRed)
        {
            PlayerRedWin.SetActive(true);

        }
    }


}
