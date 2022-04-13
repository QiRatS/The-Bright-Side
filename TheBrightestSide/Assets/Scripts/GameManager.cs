using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChanged;
    public static string CREDITS_SCENE = "Credits_scene"; // Insert the name of your credits scene here, with correct capitalizations 
    public static string TITLE_SCENE = "Title_scene"; // Insert the name of your title scene here, with correct capitalizations 
    public static List<string> LEVEL_SCENES = new List<string>(); // These will be all the level scene names. Make sure they are in order, as this is the way they will be unlocked.

    private List<bool> level_unlocks = new List<bool>();

    public GameState State;

    public bool playerDiedGameRestarted;
    public int life;
    public int collectScore;


    public GameObject gameOverScreen; // This gameobject has to be a child object of the game manager
    public GameObject loseScreen;
    public GameObject winScreen;



    private void MakeSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        MakeSingleton();
        Instance = this;
        DontDestroyOnLoad(gameOverScreen);
    }

    void Start()
    {
        UpdateGameState();
        GenerateLevelUnlockList();
    }

    private void UpdateGameState()
    {
        // When starting the game, we want to start it at the title screen by default
        UpdateGameState(GameState.Title);
    }

    public void UpdateGameState(GameState newState, string scene = "")
    {
        State = newState;

        gameOverScreen.SetActive(false); // Disable the game over screen upon changing the state of the game
        loseScreen.SetActive(false);
        winScreen.SetActive(false);

        switch (newState)
        {
            case GameState.Title:
                HandleTitle();
                break;
            case GameState.Start:
                HandleStart(scene);
                break;
            case GameState.Credits:
                HandleCredits();
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            case GameState.Restart:
                HandleRestart();
                break;
            case GameState.Win:
                HandleWin();
                break;
            default:
                throw new System.ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);

    }

    private void HandleWin()
    {
        winScreen.SetActive(true);

        // When completing a new level, we will unlock the next.
        string activeScene = SceneManager.GetActiveScene().name;
        if (LEVEL_SCENES.Contains(activeScene))
        {
            int levelIndex = LEVEL_SCENES.IndexOf(activeScene);
            if (levelIndex <= LEVEL_SCENES.Count - 2)
            {
                // Unlock the next scene
                level_unlocks[levelIndex + 1] = true;
            }
        }


    }
    private void HandleRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void HandleLose()
    {
        loseScreen.SetActive(true);
    }
    private void HandleGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    private void HandleCredits()
    {
        SceneManager.LoadScene(CREDITS_SCENE);

    }
    private void HandleTitle()
    {
        SceneManager.LoadScene(TITLE_SCENE);
    }
    private void HandleStart(string scene)
    {
        if (LEVEL_SCENES.Contains(scene))
        {
            if (level_unlocks[LEVEL_SCENES.IndexOf(scene)]) // If the level is unlocked 
            {
                SceneManager.LoadScene(scene);
            }
            else
            {
                Debug.LogWarning("This level has not been unlocked!");
            }
        }
        else
        {
            throw new ArgumentException("No valid scene was given : level not found.");
        }
    }

    private void GenerateLevelUnlockList()
    {
        foreach (string level in LEVEL_SCENES)
        {
            if (level_unlocks.Count < 2)
            {
                // Set the first level to unlocked
                level_unlocks.Add(true);
            }
            else
            {
                level_unlocks.Add(false);
            }
        }

    }
}


public enum GameState
{
    Title,
    Start,
    GameOver,
    Credits,
    Win,
    Lose,
    Restart,
    Menu,

}
