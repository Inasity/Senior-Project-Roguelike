using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject levelloader;
    
    public void PlayGame()
    {
        levelloader.GetComponent<LevelLoader>().LoadNextLevel();
    }

    public void QuitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }

}
