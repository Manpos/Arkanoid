using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    void Movement();
    
    void UpdateDirection(Vector2 direction);
}
