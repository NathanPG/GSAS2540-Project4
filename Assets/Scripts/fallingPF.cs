using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPF : MonoBehaviour
{
    bool started = false;
    bool fall = false;

    IEnumerator startfall()
    {
        yield return new WaitForSeconds(0.1f);
        fall = true;
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
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        if (transform.position.y <= 3f)
        {
            Destroy(this.gameObject);
        }
        if (fall)
        {
            pos.y -= 5f * Time.deltaTime;
            transform.position = pos;
        }
    }
}
