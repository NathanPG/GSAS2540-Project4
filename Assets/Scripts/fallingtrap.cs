using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingtrap : MonoBehaviour
{
    public GameObject player;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= transform.position.x - 1f || player.transform.position.x <= transform.position.x + 1f)
        {
            GetComponent<Rigidbody2D>().WakeUp();
        }
        if (transform.position.y <= -10f)
        {
            Destroy(this.gameObject);
        }
    }
}
