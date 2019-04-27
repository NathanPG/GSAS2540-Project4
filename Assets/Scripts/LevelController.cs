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
    public GameObject player;
    public GameObject eaglepre;
    bool GAMEEND = false;
    bool spawnstart = false;
  
    private void Awake()
    {
        fadein();
        score = 0;
        life = 3;
        time = 200f;
        GAMEEND = false;
        spawnstart = false;
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
        for (int i = 1; i <= 5; i++)
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
        if((time == 0 || life == 0) && !GAMEEND)
        {
            //fail
            GAMEEND = true;
            UpdateScore(score);
            SaveScore();
            StartCoroutine("Gameover");
        }
        //Arrived Home
        //If arrived score = score + 1000 * life + time * 10.
        if (player.transform.position.x>=121 && !GAMEEND)
        {
            GAMEEND = true;
            score += 1000 * life;
            score += (int)time * 10;
            UpdateScore(score);
            SaveScore();
            StartCoroutine("Gameover");
        }
        if(player.transform.position.x >=67f && !spawnstart)
        {
            spawnstart = true;
            InvokeRepeating("inseagle", 5f, 5f);
        }
        if(player.transform.position.x >= 120f && spawnstart)
        {
            CancelInvoke();
        }
    }

    void inseagle()
    {
        float x = Random.Range(60f, 90f);
        Vector3 pos = new Vector3(x, player.transform.position.y + 10f, -5f);
        Instantiate(eaglepre, pos, Quaternion.identity);
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
