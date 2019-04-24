using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossum : MonoBehaviour
{
    Vector3 pos1;
    Vector3 pos2;
    bool GoRight;

    private void Start()
    {
        GoRight = true;
        pos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pos2 = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if(transform.position.x <= pos1.x + 0.3f)
        {
            GoRight = true;  
        }
        else if(transform.position.x >= pos2.x - 0.3f)
        {
            GoRight = false;
        }
        if (GoRight)
        {
            transform.position = Vector3.Lerp(transform.position, pos2, 0.5f * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pos1, 0.5f * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
        }  
    }
}
