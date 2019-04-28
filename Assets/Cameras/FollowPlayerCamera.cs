﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        print(player);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            -10
        );
    }
}
