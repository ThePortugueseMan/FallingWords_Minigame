using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    float timeBeforeGameOverLoad = 1.5f;

    public void LoadStartGameScene()
    {
        SceneManager.LoadScene(0);
    }


    public void LoadGameOverScene()
    {
        StartCoroutine(LoadGameOverCoroutine());
    }

    IEnumerator LoadGameOverCoroutine()
    {
        yield return new WaitForSeconds(timeBeforeGameOverLoad);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
