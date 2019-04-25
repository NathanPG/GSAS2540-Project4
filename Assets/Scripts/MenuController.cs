using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script controls scenes, including buttons, 
/// menus, messages, switching scenes.
/// </summary>

public class MenuController : MonoBehaviour
{
    public AudioSource clicksfx;
    public AudioSource closesfx;
    public GameObject pmenu;
    public GameObject hsmenu;
    public Text hstext;

    //click start button
    public void GameStart()
    {
        if (PlayerPrefs.GetInt("isSfxOn") == 1)
        {
            clicksfx.Play();
        }
        SceneManager.LoadScene("PlayingScene");

    }
    //click quit button
    public void GameQuit()
    {
        if (PlayerPrefs.GetInt("isSfxOn") == 1)
        {
            closesfx.Play();
        }
        Application.Quit();
    }

    public void checkscore()
    {
        if (!PlayerPrefs.HasKey("High Score 1: "))
        {
            for (int i = 1; i <= 5; i++)
            {
                string hsnum = "High Score " + i + ": ";
                PlayerPrefs.SetInt(hsnum, 0);
            }
        }
        string hsname = "";
        string highscoretext = "";
        for (int i = 1; i <= 5; i++)
        {
            hsname = "High Score " + i + ": ";
            highscoretext += "High Score " + i + ": " + PlayerPrefs.GetInt(hsname) + "\n";
            PlayerPrefs.SetString("High Score Text", highscoretext);
        }
    }

    //click high score button
    public void DisplayHighScore()
    {
        if (PlayerPrefs.GetInt("isSfxOn") == 1)
        {
            clicksfx.Play();
        }
        hstext.text = PlayerPrefs.GetString("High Score Text");
        hsmenu.SetActive(true);
    }

    //click cross button in highscore menu
    public void closeHS()
    {
        if (PlayerPrefs.GetInt("isSfxOn") == 1)
        {
            closesfx.Play();
        }
        hsmenu.SetActive(false);
    }

    //click pause button
    public void PauseMenu()
    {
        if (pmenu.activeInHierarchy)
        {
            if (PlayerPrefs.GetInt("isSfxOn") == 1)
            {
                closesfx.Play();
            }
            pmenu.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt("isSfxOn") == 1)
            {
                clicksfx.Play();
            }
            pmenu.SetActive(true);
        }
    }

    //click cross button in pause menu
    public void resumegame()
    {
        if (PlayerPrefs.GetInt("isSfxOn") == 1)
        {
            closesfx.Play();
        }
        pmenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        checkscore();
        hsmenu.SetActive(false);
        pmenu.SetActive(false);
    }
}
