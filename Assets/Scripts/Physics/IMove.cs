using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    void Movement();
    
    void AppliedForce(Vector2 direction);
}
