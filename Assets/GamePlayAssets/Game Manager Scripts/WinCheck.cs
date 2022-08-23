using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    public GameStateMachine manager;
    public GameObject PlayerRedWin;
    public GameObject PlayerWhiteWin;
    public GameObject PlayerRed;
    public GameObject PlayerWhite;
    public GameObject restartButton;
    bool Winning = false;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.Winning==true)
        {
            return;
        }

        if (collision.gameObject== PlayerWhite)
        {
            PlayerWhiteWin.SetActive(true);
            Debug.Log("player won");
            this.Winning = true;
        }
        else if (collision.gameObject== PlayerRed)
        {
            PlayerRedWin.SetActive(true);
            this.Winning = true;
        } 
        
        restartButton.SetActive(true);
        manager.GameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
        manager.CurrentGame();
    }


}
