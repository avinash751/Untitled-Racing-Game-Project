using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    public GameState gamestate;
    public GameObject StartButton;
    public enum GameState
    {
        Start,
        Current,
        Gameover
    }
    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        
        gamestate = GameState.Start;
        StartButton.SetActive(true);
        Time.timeScale = 1;
        Camera.main.GetComponent<Camerahumaid>().speed = 0;
        Controls[] AllPlayer = FindObjectsOfType<Controls>();
        foreach(Controls c in AllPlayer)
        {
            c.speed = 0;
        }
    }

    // Update is called once per frame
    public void CurrentGame()
    {
        if(gamestate!=GameState.Current)
        {
            gamestate = GameState.Current;
            StartButton.SetActive(false);

            Camera.main.GetComponent<Camerahumaid>().speed = 8;
            Controls[] AllPlayer = FindObjectsOfType<Controls>();
            foreach (Controls c in AllPlayer)
            {
                c.speed = 8;
            }
        }
        else
        {
            return;
        }
       
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gamestate = GameState.Gameover;
        StartButton.SetActive(false);
    }


}
