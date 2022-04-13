using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] Transform[] enemySpawnLocations;
    bool objectivesMet;
    Scene currentScene;

    public bool ObjectivesMet { get => objectivesMet; set => objectivesMet = value; }

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Call when player reaches the end of the level
    public void EndLevel()
    {
        if (!objectivesMet)
        {
            // Go to lose scene

            return;
        }
        
        // YAY the player completed the level with all objectives completed
    }

    public void MoveToScene(string sceneName_)
    {
        if (SceneManager.GetActiveScene().name == sceneName_) return;

        SceneManager.LoadScene(sceneName_);
    }

    public void MoveToScene(Scene scene_)
    {
        if (SceneManager.GetActiveScene().name == scene_.name) return;

        SceneManager.LoadScene(scene_.name);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentScene.name);
    }

    // For when reseting the level without reloading the entire scene
    public void ResetScene()
    {
        objectivesMet = false;
    }

    // Spawn Location Methods
    
}
