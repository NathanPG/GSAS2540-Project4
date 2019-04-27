using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour
{
    public AudioSource collect;
    public LevelController level;
    private void Awake()
    {
        collect = GameObject.FindGameObjectWithTag("collect").GetComponent<AudioSource>();
        level = GameObject.FindGameObjectWithTag("controller").GetComponent<LevelController>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("isSfxOn") == 1)
            {
                collect.Play();
            }
            level.addscore();
            Destroy(this.gameObject);
        }

    }
}
