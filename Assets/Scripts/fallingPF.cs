using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPF : MonoBehaviour
{
    bool started = false;
    bool fall = false;
    bool respawn;
    Vector3 pos;

    IEnumerator startfall()
    {
        yield return new WaitForSeconds(0.1f);
        fall = true;
    }

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(3f);
        transform.position = pos;
        started = false;
        respawn = true;
    }

    private void Awake()
    {
        respawn = true;
        //GetComponent<SpriteRenderer>().enabled = true;
        pos = transform.position;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !started)
        {
            StartCoroutine("startfall");
            started = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            fall = false;
        }
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        if (transform.position.y <= 3f)
        {
            //GetComponent<SpriteRenderer>().enabled = false;
            fall = false;
            if (respawn)
            {
                StartCoroutine("spawn");
                respawn = false;
            }
        }
        if (fall)
        {
            pos.y -= 5f * Time.deltaTime;
            transform.position = pos;
        }
    }
}
