using System;
using UnityEngine;

public class Ball : MovingObject, ICollide
{
    [SerializeField]
    private Vector2 _initialDirection;

    public Vector2 InitialDirection => _initialDirection;

    private Vector3 _initialPosition;

    public Vector3 InitialPosition => _initialPosition;

    private Vector2 _previousDirection;

    private void Awake()
    {
        _initialPosition = transform.position;
        _previousDirection = _initialDirection;
    }

    private void Start()
    {
        PhysicsManager.OnPhysics.AddListener(Movement);
        AppliedForce(_previousDirection);
    }

    private void Update()
    {
        AppliedForce(_previousDirection);
    }

    public void ResetDirection()
    {
        _previousDirection = _initialDirection;
    }

    public void ResetPosition()
    {
        transform.position = _initialPosition;
    }

    public void Collision(Vector2 normal)
    {
        _previousDirection = ReflectionVector(normal.normalized, _previousDirection);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<ICollide>() != null)
        {
            Collision(other.GetContact(0).normal);
        }
    }
}
