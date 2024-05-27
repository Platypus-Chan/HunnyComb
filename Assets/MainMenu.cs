using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Debug.Log("The Game Has Exited!");
        Application.Quit();
    }
}
