using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotateSpeed = 10f;
    public GameObject player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Trap")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(player.transform.position - transform.position),rotateSpeed * Time.deltaTime);
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y,-5f), new Vector3(player.transform.position.x, player.transform.position.y, -5f), 0.5f * Time.deltaTime);
        if (transform.position.x <= player.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
