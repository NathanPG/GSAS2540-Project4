using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector3 playerpos = player.transform.position;
        //TODO: ADD RIGHT BOUND
        if (playerpos.x >= 0 && playerpos.y >=0)
        {
            this.transform.position = new Vector3(playerpos.x, playerpos.y, -100);
        }
        else if(playerpos.x < 0 && playerpos.y >= 0)
        {
            this.transform.position = new Vector3(0, playerpos.y, -100);
        }
        else if (playerpos.x >= 0 && playerpos.y < 0)
        {
            this.transform.position = new Vector3(playerpos.x, 0, -100);
        }
        else
        {
            this.transform.position = new Vector3(0, 0, -100);
        }
    }
}
