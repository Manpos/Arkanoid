using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceVector
{
    public Vector2 Direction { get; }
    public float Force { get; }

    public ForceVector(Vector2 direction, float force)
    {
        Direction = direction;
        Force = force;
    }
}
