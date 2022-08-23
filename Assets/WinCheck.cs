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

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject== PlayerWhite)
        {
            PlayerWhiteWin.SetActive(true);
            Debug.Log("player won");
            
        }
        else if (collision.gameObject== PlayerRed)
        {
            PlayerRedWin.SetActive(true);
        } 
        
        restartButton.SetActive(true);
        //RestartGame();
        manager.GameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        manager.CurrentGame();
    }


}
