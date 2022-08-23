using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine : MonoBehaviour
{
    public GameState gamestate;

    public enum GameState
    {
        Start,
        Current,
        Gameover
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        gamestate = GameState.Start;
    }

    // Update is called once per frame
    void CurrentGame()
    {
        gamestate = GameState.Current;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gamestate = GameState.Gameover;
    }


}
