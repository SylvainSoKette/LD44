using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask collisionMask;
    public float speed = 10f;
    public float maxLifeTime = 1.0f;

    // public float[] shotSpread = new float[] { -1.0f, 1.0f };

    void Update()
    {
        Destroy(this.gameObject, this.maxLifeTime);
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        this.transform.Translate(Vector3.up * moveDistance);
    }
    
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(this.transform.position, this.transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide)) {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        GameObject.Destroy(hit.collider.gameObject);
        GameObject.Destroy(gameObject);
    }
}
