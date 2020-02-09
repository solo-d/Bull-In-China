using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState //works like objects and passed in as parameters
{
    menu, //
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake() //used to access GM from anywhere in the code
    {
        instance = this;
    }

    public GameState currentGameState = GameState.menu;

    void Start()
    {
        StartGame();
    }


    //Start Game
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    //When player loses, open menu to try again or quit
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    //when player goes to the menu?
    public void BacktoMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState (GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //setup Unity scene for menu state
        }
        else if (newGameState == GameState.inGame)
        {
            //setup Unity scene for inGame state
        }
        else if (newGameState == GameState.gameOver)
        {
            //setup Unity scene for gameOver state
        }

        currentGameState = newGameState;
    }
}
