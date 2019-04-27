using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2f;

    public float[] shotSpread = new float[] {-1.0f, 1.0f};

    bool canMove = true;

    public Rigidbody bullet;

    public float shootSpeed = 5f;

    public float shootRate = 0.25f;
    float lastShot = .3f;

    void Update()
    {
        if (CanMove())
        {
            Move();
            Shoot();
        }
    }

    void Move()
    {
        // Player Move
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
        Vector3 movement = new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0);
        this.transform.position = new Vector3(
            this.transform.position.x + movement.x,
            this.transform.position.y + movement.y,
            0
        );


        // Player aim
        var mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
        var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg + 270;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > shootRate + lastShot)
            {
                Rigidbody instantiateProjectile = Instantiate(
                    bullet,
                    bullet.transform.position,
                    this.transform.rotation
                ) as Rigidbody;


                instantiateProjectile.velocity = this.transform.TransformDirection(new Vector3(Random.Range(shotSpread[0], shotSpread[1]), shootSpeed, 0));

                lastShot = Time.time;
            }
        }
    }

    void SetAllowToMove(bool allow)
    {
        canMove = allow;
    }

    bool CanMove()
    {
        return canMove;
    }
}
