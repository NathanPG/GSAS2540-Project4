using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public GameObject pmenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //click quit button
    public void GameQuit()
    {
        Application.Quit();
    }

    //click the restart button
    public void restart()
    {
        SceneManager.LoadScene("PlayingScene");
    }

    //click pause button
    public void PauseMenu()
    {
        Time.timeScale = 0;
        pmenu.SetActive(true);
        if (pmenu.activeInHierarchy)
        {
            pmenu.SetActive(false);
        }
    }

    //click cross button in pause menu
    public void resumegame()
    {
        Time.timeScale = 1;
        pmenu.SetActive(false);
    }
}
