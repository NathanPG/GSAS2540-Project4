using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public GameObject pmenu;
    public Text hstext;
    public AudioSource clicksfx;
    public AudioSource closesfx;

    private void Awake()
    {
        hstext.text = PlayerPrefs.GetString("High Score Text");
    }

    //click menu button
    public void backtomenu()
    {
        if (PlayerPrefs.GetInt("isSfxOn") == 1)
        {
            clicksfx.Play();
        }
        SceneManager.LoadScene("Menu");
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

    //click the restart button
    public void restart()
    {
        if (PlayerPrefs.GetInt("isSfxOn") == 1)
        {
            clicksfx.Play();
        }
        SceneManager.LoadScene("PlayingScene");
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
}
