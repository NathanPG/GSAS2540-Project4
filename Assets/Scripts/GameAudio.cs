﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public AudioSource music;
    public AudioSource jump;
    public AudioSource hurt;
    public Slider MusicSlider;
    public Slider SfxSlider;
    public Toggle mutemusic;
    public Toggle mutesfx;

    //music slider
    public void AdjustMusic()
    {
        music.volume = MusicSlider.value;
        PlayerPrefs.SetFloat("music", MusicSlider.value);
    }

    //sfx slider
    public void AdjustSFX()
    {
        jump.volume = SfxSlider.value;
        hurt.volume = SfxSlider.value;
        PlayerPrefs.SetFloat("sfx", SfxSlider.value);
    }

    //mute music button
    public void MuteMusic()
    {
        if (mutemusic.isOn)
        {
            music.mute = true;
            PlayerPrefs.SetInt("isMusicOn", 0);
        }
        else
        {
            music.mute = false;
            PlayerPrefs.SetInt("isMusicOn", 1);
        }
    }

    //mute sfx button
    public void MuteSFX()
    {
        if (mutesfx.isOn)
        {
            jump.volume = 0f;
            hurt.volume = 0f;
            PlayerPrefs.SetInt("isSfxOn", 0);
        }
        else
        {
            jump.volume = PlayerPrefs.GetFloat("sfx");
            hurt.volume = PlayerPrefs.GetFloat("sfx");
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
            jump.volume = SfxSlider.value;
            hurt.volume = SfxSlider.value;
        }
        else
        {
            PlayerPrefs.SetFloat("sfx", 1f);
            SfxSlider.value = 1f;
            jump.volume = SfxSlider.value;
            hurt.volume = SfxSlider.value;
        }

        //music volume
        if (PlayerPrefs.HasKey("music"))
        {
            MusicSlider.value = PlayerPrefs.GetFloat("music");
            music.volume = MusicSlider.value;
        }
        else
        {
            PlayerPrefs.SetFloat("music", 1f);
            MusicSlider.value = 1f;
            music.volume = MusicSlider.value;
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