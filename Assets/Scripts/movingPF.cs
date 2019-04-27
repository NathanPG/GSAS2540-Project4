using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPF : MonoBehaviour
{
    Vector3 pos1;
    Vector3 pos2;
    float movespeed = 1f;
    bool GoRight;
    // Start is called before the first frame update
    void Start()
    {
        GoRight = true;
        pos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pos2 = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (transform.position.x <= pos1.x + 0.3f)
        {
            GoRight = true;
        }
        else if (transform.position.x >= pos2.x - 0.3f)
        {
            GoRight = false;
        }
        if (GoRight)
        {
            pos.x += movespeed * Time.deltaTime;
            transform.position = pos;
        }
        else
        {
            pos.x -= movespeed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
