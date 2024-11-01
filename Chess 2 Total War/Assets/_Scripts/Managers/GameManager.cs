using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State; //From the enum below

    public static event Action<GameState> OnGameStateChanged; //Not sure what this does yet

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.GenerateGrid);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnBlacks:
                UnitManager.Instance.SpawnBlacks();
                break;
            case GameState.SpawnWhites:
                break;
            case GameState.BlackTurn:
                break;
            case GameState.WhiteTurn:
                break;
            default:
                //If newState somehow isn't any of these, throw an error
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState); //We assume that if there is no change, no error will run 
    }

}

public enum GameState
{
    GenerateGrid = 0,
    SpawnBlacks = 1,
    SpawnWhites = 2,
    BlackTurn = 3,
    WhiteTurn = 4
}
