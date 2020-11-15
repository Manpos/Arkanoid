using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour, IMove
{
    [SerializeField]
    protected RectTransform _objectTrasform;
    
    [SerializeField]
    protected float _speed;
    
    protected Vector2 _direction = Vector2.zero;

    protected Queue<Vector2> _appliedForces = new Queue<Vector2>();
    
    public virtual void Movement()
    {
        if (_appliedForces.Count > 0)
        {
            _direction = _appliedForces.Dequeue();
            _objectTrasform.Translate(_direction.normalized * _speed * Time.deltaTime);
        }
        else
        {
            _direction = Vector2.zero;
        }
    }
    
    public virtual void AppliedForce(Vector2 direction)
    {
        _appliedForces.Enqueue(direction);
    }
    
    protected Vector2 ReflectionVector(Vector2 normal, Vector2 direction)
    {
        return direction - 2 * Vector2.Dot(normal, direction) * normal;
    }
    
}
