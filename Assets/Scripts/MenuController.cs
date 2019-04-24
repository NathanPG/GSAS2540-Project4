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
    //public Information info;
    //public bool isGameStart = false;
    //public bool isFirstScene = true;
    //public bool isGameend = false;
    
    public GameObject pmenu;
    //public GameObject mainmenu;
    //public GameObject EndMenu;
    public GameObject hsmenu;
    public Text hstext;

    private void OnEnable()
    {
        //Information.openmenu += pausemenu;
    }

    public void pausemenu()
    {
        Time.timeScale = 0;
        pmenu.SetActive(true);
    }

    ////click start button
    public void GameStart()
    {
        //isFirstScene = true;
        SceneManager.LoadScene("PlayingScene");
        //regularui.SetActive(true);
        //mainmenu.SetActive(false);
        //info.score = 0;
        //info.life = 3;
        //info.updatescore();
        //info.updatelife();
    }
    //click quit button
    public void GameQuit()
    {
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
        hstext.text = PlayerPrefs.GetString("High Score Text");
        hsmenu.SetActive(true);
    }

    //click cross button in highscore menu
    public void closeHS()
    {
        hsmenu.SetActive(false);
    }

    //click pause button
    public void PauseMenu()
    {
        if (pmenu.activeInHierarchy)
        {
            pmenu.SetActive(false);
        }
        else
        {
            pmenu.SetActive(true);
        }
    }

    //click cross button in pause menu
    public void resumegame()
    {
        pmenu.SetActive(false);
    }

    ////click restart button in the last scene
    //public void Restart()
    //{
    //    smsgobject.SetActive(true);
    //    regularui.SetActive(true);
    //    SceneManager.LoadScene("PlayingScene");
    //    info.score = 0;
    //    info.life = 3;
    //    info.time = 60;
    //    info.updatescore();
    //    info.updatelife();
    //    isFirstScene = true;
    //    HSmenu.SetActive(false);
    //    EndMenu.SetActive(false);
    //    wmsgobject.SetActive(false);
    //    fmsgobject.SetActive(false);
    //}



    // Start is called before the first frame update
    void Start()
    {
        checkscore();
        hsmenu.SetActive(false);
        pmenu.SetActive(false);
        //regularui.SetActive(false);
        //smsgobject.SetActive(false);
        //wmsgobject.SetActive(false);
        //fmsgobject.SetActive(false);
        //isGameStart = false;
        //isFirstScene = false;
        //EndMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //    if ((info.time <= 0 || info.life == 0) && isGameStart)
        //    {
        //        SceneManager.LoadScene("EndScene");
        //        EndMenu.SetActive(true);
        //        if(info.life == 0)
        //        {
        //            fmsgobject.SetActive(true);
        //        }
        //        else
        //        {
        //            wmsgobject.SetActive(true);
        //        }
        //        info.UpdateScore(info.score);
        //        info.DisplayScore();
        //        //EnemySpawner destroied
        //        info.respawning = false;
        //        info.clearscreen = false;
        //        HSmenu.SetActive(true);
        //        regularui.SetActive(false);
        //        isGameStart = false;
        //    }
        //    //first start
        //    else if (isFirstScene)
        //    {
        //        info.time = 60;
        //        smsgobject.SetActive(true);
        //        if (Input.GetMouseButton(0))
        //        {
        //            isGameStart = true;
        //            isFirstScene = false;
        //            smsgobject.SetActive(false);
        //        }
        //    }
    }
}
