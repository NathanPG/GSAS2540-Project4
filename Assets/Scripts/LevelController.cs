using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This script is to control scores
/// </summary>
public class LevelController : MonoBehaviour
{
    public int score;
    public int life;

    public GameObject pmenu;
    public float time;
    public Text scoredisplay;
    public Text lifedisplay;
    public Text timedisplay;
  
    private void Awake()
    {
        fadein();
        score = 0;
        life = 3;
        time = 200;
    }
    public void fadeout()
    {
        GetComponent<Animator>().SetBool("Faded", true);
    }
    public void fadein()
    {
        GetComponent<Animator>().SetBool("Faded", false);
    }

    private void OnEnable()
    {
        Player.isHurt += loseLife;
        Player.isHurt += fadeout;
        Player.isIn += fadein;
    }
    public void OnDisable()
    {
        Player.isHurt -= loseLife;
        Player.isHurt -= fadeout;
        Player.isIn -= fadein;
    }

    //Add score by 10
    public void addscore()
    {
        score += 100;
        scoredisplay.text = string.Format("scores:{0,4}", score);
    }

    //Lose one life
    public void loseLife()
    {
        life -= 1;
        lifedisplay.text = string.Format("life:{0,4}/3", life);
    }
    //Add one life
    public void addLife()
    {
        life += 1;
        lifedisplay.text = string.Format("life:{0,4}", life);
    }


    //Update playerpref of score
    public void UpdateScore(int currentscore)
    {
        string tempstring = "";
        for (int i = 1; i <= 10; i++)
        {
            tempstring = "High Score " + i + ": ";
            if (PlayerPrefs.GetInt(tempstring) < currentscore)
            {
                PlayerPrefs.SetInt(tempstring, currentscore);
                return;
            }
        }
    }
    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EndScene");
    }

    ////Update the score text object
    public void SaveScore()
    {
        string hsname = "";
        string highscoretext = "";
        for (int i = 1; i <= 5; i++)
        {
            hsname = "High Score " + i + ": ";
            highscoretext += "High Score " + i + ": " + PlayerPrefs.GetInt(hsname) + "\n";
            PlayerPrefs.SetString("High Score Text", highscoretext);
        }
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            timedisplay.text = string.Format("Time:{0:00.00}/200", time);
            if (time >= 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = 0;
            }
        }
        if(time == 0 || life == 0)
        {
            //fail
            //score = coinscore
            UpdateScore(score);
            StartCoroutine("Gameover");
        }
        //Arrived Home
        //If arrived score = 1000*life + coin_score + (200-time) * 10.
    }

    //click pause button
    public void PauseMenu()
    {
        if (pmenu.activeInHierarchy)
        {
            Time.timeScale = 1;
            pmenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pmenu.SetActive(true);
        }
    }

    //click cross button in pause menu
    public void resumegame()
    {
        Time.timeScale = 1;
        pmenu.SetActive(false);
    }
}
