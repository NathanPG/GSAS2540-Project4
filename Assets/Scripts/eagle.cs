using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotateSpeed = 10f;
    GameObject player;
    float xspeed;
    float yspeed;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
    private void Awake()
    {
        xspeed = 1f;
        yspeed = 1f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 pos = transform.position;
        //transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(player.transform.position - transform.position),rotateSpeed * Time.deltaTime);
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y,-5f), new Vector3(player.transform.position.x, player.transform.position.y, -5f), 0.5f * Time.deltaTime);
        if(System.Math.Abs(transform.position.x - player.transform.position.x) >= 10f)
        {
            xspeed = 2f;
        }
        else
        {
            xspeed = 1f;
        }
        if (transform.position.x <= player.transform.position.x)
        {
            pos.x += xspeed * Time.deltaTime;
            transform.position = pos;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            pos.x -= xspeed * Time.deltaTime;
            transform.position = pos;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (transform.position.y <= player.transform.position.y)
        {
            pos.y += yspeed * Time.deltaTime;
            transform.position = pos;
        }
        else
        {
            pos.y -= yspeed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
