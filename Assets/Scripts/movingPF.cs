using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPF : MonoBehaviour
{
    Vector3 pos2;
    float movespeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        pos2 = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        //move left
        if (transform.position.x > pos2.x)
        {
            pos.x += movespeed * Time.deltaTime;
            transform.position = pos;
        }
        //move right
        else if (transform.position.x < pos2.x)
        {
            pos.x -= movespeed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
