using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 0.5f;

    private GameObject player;

    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Vector3 direction = new Vector3(
            this.player.transform.position.x - this.transform.position.x,
            this.player.transform.position.y - this.transform.position.y,
            -0.5f
        ).normalized;

        Vector3 movement = new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, -0.5f);

        this.transform.position = new Vector3(
            this.transform.position.x + movement.x,
            this.transform.position.y + movement.y,
            -0.5f
        );
    }

    public void Initiate()
    {
        this.player = GameObject.Find("Player");
        this.speed = Random.Range(2.0f, 4.0f);
    }
}
