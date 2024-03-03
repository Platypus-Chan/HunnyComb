using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public Texture startTexture;

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 64;
        style.fontStyle = FontStyle.BoldAndItalic;
 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), startTexture);
        //GUI.Label(new Rect(Screen.width/2-250, Screen.height / 2 - 250, 200, 200), "               HunnyComb \n          Sakura's Blessing", style);

        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 450, 75), "Embark"))
        {
            SceneManager.LoadScene("Battlegrounds 1");
        }

        /*if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 25, 150, 25), "Play Level 2"))
        {
            SceneManager.LoadScene("Scene2");
        }

        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 50, 150, 25), "Credits"))
        {
            SceneManager.LoadScene("GameOver");
        }
        */

        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 150, 450, 75), "Flee"))
        {
            Application.Quit();
        }
    }
}
