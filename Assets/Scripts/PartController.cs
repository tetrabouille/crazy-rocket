using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartController : MonoBehaviour
{
    private CollisionHandler collisionHandler;

    void Start()
    {
        collisionHandler = gameObject.GetComponentInParent<CollisionHandler>();
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        collisionHandler.HandleCollision(other);
    }
}
