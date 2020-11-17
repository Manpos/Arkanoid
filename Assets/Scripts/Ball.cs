using UnityEngine;

public class Ball : MovingObject, ICollide
{
    [SerializeField]
    private Vector2 _initialDirection;

    private Vector2 _previousDirection;
    private void Start()
    {
        PhysicsManager.OnPhysics.AddListener(Movement);
        AppliedForce(_initialDirection);
    }

    private void Update()
    {
        AppliedForce(_initialDirection);
    }

    public void Collision(Vector2 normal)
    {
        _initialDirection = ReflectionVector(normal.normalized, _initialDirection);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<ICollide>() != null)
        {
            Collision(other.GetContact(0).normal);
        }
    }
}
