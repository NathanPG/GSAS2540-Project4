using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingtrap : MonoBehaviour
{
    public GameObject player;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= transform.position.x - 2f)
        {
            GetComponent<Rigidbody2D>().WakeUp();
        }
        if (transform.position.y <= -10f)
        {
            Destroy(this.gameObject);
        }
    }
}
