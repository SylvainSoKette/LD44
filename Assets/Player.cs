using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
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
}
