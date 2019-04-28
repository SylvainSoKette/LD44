using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed = 2f;
    
    bool canMove = true;

    public GameObject canon;

    public Bullet bullet;

    public float shootRate = 100;

    public float bulletVelocity = 35;

    float nextShotTime;

    int thune = 666;

    void Update()
    {
        if (CanMove())
        {
            Move();
            Aim();
            Shoot();
        }
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
        Vector3 movement = new Vector3(direction.x * Time.deltaTime * speed, direction.y * Time.deltaTime * speed, 0);
        
        float newX = this.transform.position.x + movement.x;
        float newY = this.transform.position.y + movement.y;

        float mapSize = 128f;
        if (newX > mapSize) newX = mapSize;
        if (newX < -mapSize) newX = -mapSize;
        if (newY > mapSize) newY = mapSize;
        if (newY < -mapSize) newY = -mapSize;

        this.transform.position = new Vector3(
            newX,
            newY,
            0
        );
    }

    public void Aim()
    {
        var mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
        var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg + 270;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + shootRate / 1000;

                Bullet newBullet = Instantiate(bullet, canon.transform.position, canon.transform.rotation) as Bullet;
                newBullet.SetSpeed(bulletVelocity);
                // newBullet.velocity = this.transform.TransformDirection(new Vector3(
                //     Random.Range(shotSpread[0], 
                //     shotSpread[1]),
                //     bulletVelocity, 0));
            }
        }
    }

    public int getThune()
    {
        return this.thune;
    }

    public void SetAllowToMove(bool allow)
    {
        canMove = allow;
    }

    public bool CanMove()
    {
        return canMove;
    }
}
