using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    float ideltime = 2f;
    bool jumpstart = false;
    IEnumerator startjump()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().SetBool("frogjump", true);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
    }
    IEnumerator endjump()
    {
        yield return new WaitForSeconds(2f + 1f);
        GetComponent<Animator>().SetBool("frogjump", false);
        ideltime = 2f;
        jumpstart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ideltime > 0)
        {
            ideltime -= Time.deltaTime;
        }
        else
        {
            ideltime = 0f;
            if (!jumpstart)
            {
                jumpstart = true;
                StartCoroutine("startjump");
                StartCoroutine("endjump");
            }
        }
    }
}
