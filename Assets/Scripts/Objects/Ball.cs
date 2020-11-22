using Physics;
using UnityEngine;

namespace Objects
{
    public class Ball : MovingObject, ICollide
    {
        #region Serialized Fields

        [SerializeField]
        private Vector2 _initialDirection;

        #endregion

        #region Standard Attributes
        
        private Vector2 _currentDirection;

        #endregion

        #region API Methods
        
        private void Awake()
        {
            _currentDirection = _initialDirection;
        }

        private void Start()
        {
            PhysicsManager.OnPhysics.AddListener(Movement);
            UpdateDirection(_currentDirection);
        }

        private void Update()
        {
            if(_appliedForces.Count == 0) UpdateDirection(_currentDirection);
        }
        
        public void Collision(Vector2 normal)
        {
            _currentDirection = ReflectionVector(normal.normalized, _currentDirection);
        }

        #endregion

        #region Other methods

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<ICollide>() == null)
            {
                return;
            }

            Vector2 normalAverage = Vector2.zero;
            foreach (ContactPoint2D contact in other.contacts)
            {
                normalAverage += contact.normal;
            }

            normalAverage /= other.contacts.Length;
            Collision(normalAverage);
        }

        #endregion
    }
}
