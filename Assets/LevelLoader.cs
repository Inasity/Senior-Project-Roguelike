using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("m"))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadPreviousLevel()
    {
        Health.resetHealth(Health.startingHealth, Health.startingHearts);
        PlayerController.resetStats(PlayerController.moveSpeedStart, PlayerController.fireDelayStart, PlayerController.bulletSizeStart, PlayerController.bulletDamageStart);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void LoadVictoryScreen()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void LoadGameLevel()
    {
        Health.resetHealth(Health.startingHealth, Health.startingHearts);
        PlayerController.resetStats(PlayerController.moveSpeedStart, PlayerController.fireDelayStart, PlayerController.bulletSizeStart, PlayerController.bulletDamageStart);
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
