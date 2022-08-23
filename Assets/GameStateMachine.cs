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
        Time.timeScale = 0;
        gamestate = GameState.Start;
        StartButton.SetActive(true);
    }

    // Update is called once per frame
    public void CurrentGame()
    {
        gamestate = GameState.Current;
        Time.timeScale = 1;
        StartButton.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gamestate = GameState.Gameover;
        StartButton.SetActive(false);
    }


}
