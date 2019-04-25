using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndAudio : MonoBehaviour
{
    public AudioSource click;
    public AudioSource close;
    public Slider MusicSlider;
    public Slider SfxSlider;
    public Toggle mutemusic;
    public Toggle mutesfx;

    //music slider
    public void AdjustMusic()
    {
        PlayerPrefs.SetFloat("music", MusicSlider.value);
    }

    //sfx slider
    public void AdjustSFX()
    {
        click.volume = SfxSlider.value;
        close.volume = SfxSlider.value;
        PlayerPrefs.SetFloat("sfx", SfxSlider.value);
    }

    //mute music button
    public void MuteMusic()
    {
        if (mutemusic.isOn)
        {
            PlayerPrefs.SetInt("isMusicOn", 0);
        }
        else
        {
            PlayerPrefs.SetInt("isMusicOn", 1);
        }
    }

    //mute sfx button
    public void MuteSFX()
    {
        if (mutesfx.isOn)
        {
            click.volume = 0f;
            close.volume = 0f;
            PlayerPrefs.SetInt("isSfxOn", 0);
        }
        else
        {
            click.volume = PlayerPrefs.GetFloat("sfx");
            close.volume = PlayerPrefs.GetFloat("sfx");
            PlayerPrefs.SetInt("isSfxOn", 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //sfx volume
        if (PlayerPrefs.HasKey("sfx"))
        {
            SfxSlider.value = PlayerPrefs.GetFloat("sfx");
            click.volume = SfxSlider.value;
            close.volume = SfxSlider.value;
        }
        else
        {
            PlayerPrefs.SetFloat("sfx", 1f);
            SfxSlider.value = 1f;
            click.volume = SfxSlider.value;
            close.volume = SfxSlider.value;
        }

        //music volume
        if (PlayerPrefs.HasKey("music"))
        {
            MusicSlider.value = PlayerPrefs.GetFloat("music");
        }
        else
        {
            PlayerPrefs.SetFloat("music", 1f);
            MusicSlider.value = 1f;
        }

        //music on or off
        if (!PlayerPrefs.HasKey("isMusicOn"))
        {
            PlayerPrefs.SetInt("isMusicOn", 1);
        }
        else
        {
            if (PlayerPrefs.GetInt("isMusicOn") == 1)
            {
                mutemusic.isOn = false;
            }
            else
            {
                mutemusic.isOn = true;
            }
        }

        //sfx on or off
        if (!PlayerPrefs.HasKey("isSfxOn"))
        {
            PlayerPrefs.SetInt("isSfxOn", 1);
        }
        else
        {
            if (PlayerPrefs.GetInt("isSfxOn") == 1)
            {
                mutesfx.isOn = false;
            }
            else
            {
                mutesfx.isOn = true;
            }
        }
    }
}
