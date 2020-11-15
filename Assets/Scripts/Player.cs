﻿using System;
using UnityEngine;

public class Player : MovingObject, ICollide
{

    public bool LeftLimit { get; private set; }
    
    public bool RightLimit { get; private set; }

    private void Start()
    {
        PhysicsManager.OnPhysics.AddListener(Movement);
    }
    
    public void Collision(Vector2 normal)
    {
        if (normal == Vector2.left)
        {
            RightLimit = true;
        }
        else if (normal == Vector2.right)
        {
            LeftLimit = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<ICollide>() != null && other.gameObject.CompareTag("Wall"))
        {
            Collision(other.GetContact(0).normal);
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<ICollide>() != null && other.gameObject.CompareTag("Wall"))
        {
            Collision(other.GetContact(0).normal);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        LeftLimit = false;
        RightLimit = false;
    }
}
