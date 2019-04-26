using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPF : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody2D>().WakeUp();
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
