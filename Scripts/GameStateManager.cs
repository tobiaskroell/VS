using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameStateManager : MonoBehaviour
{
    private GameManager gameManager;
    private GameManager.GameState currentGameState;



    public void ChangeGameState()
    {
        switch (currentGameState)
        {

            case GameManager.GameState.Choice01:
                currentGameState = GameManager.GameState.Choice02;
                Debug.Log("GameState.Choice02 entered - Current State: " + currentGameState);
                break;
            case GameManager.GameState.Choice02:
                currentGameState = GameManager.GameState.Choice03;
                Debug.Log("GameState.Choice03 entered - Current State: " + currentGameState);
                break;
            case GameManager.GameState.Choice03:
                currentGameState = GameManager.GameState.Choice04;
                Debug.Log("GameState.Choice04 entered - Current State: " + currentGameState);
                break;
            case GameManager.GameState.Choice04:
                currentGameState = GameManager.GameState.PostChoice05;
                Debug.Log("GameState.PostChoice05 entered - Current State: " + currentGameState);
                break;
        }
    }
}
