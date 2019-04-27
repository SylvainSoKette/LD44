﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // public LayerMask collisionMask;
    float speed = 10f;

    // public float[] shotSpread = new float[] { -1.0f, 1.0f };

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        // CheckCollisions(moveDistance);
        this.transform.Translate(Vector3.up * moveDistance);
    }
    
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // void CheckCollisions(float moveDistance)
    // {
    //     Ray ray = new Ray(this.transform.position, this.transform.forward);
    //     RaycastHit hit;

    //     if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide)) {
    //         OnHitObject(hit);
    //     }
    // }

    // void OnHitObject(RaycastHit hit)
    // {
    //     print("Hit !");
    //     print(hit.collider.gameObject.name);
    //     // GameObject.Destroy(gameObject);
    // }
}
