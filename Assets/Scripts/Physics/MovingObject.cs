using System.Collections.Generic;
using UnityEngine;

namespace Physics
{
    public abstract class MovingObject : MonoBehaviour, IMove
    {
        #region Serialized Fields

        [SerializeField]
        protected RectTransform _objectTrasform;
    
        [SerializeField]
        protected float _speed;

        #endregion

        #region Standard Attributes

        private Vector2 _direction = Vector2.zero;

        protected Queue<Vector2> _appliedForces = new Queue<Vector2>();

        #endregion

        #region API Methods

        /// <summary>
        /// Function defining the movement of the object
        /// </summary>
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
    
        /// <summary>
        /// Applies a direction to the movement
        /// </summary>
        /// <param name="direction"> New direction </param>
        public virtual void UpdateDirection(Vector2 direction)
        {
            _appliedForces.Enqueue(direction);
        }

        #endregion


        #region Other Methods

        /// <summary>
        /// Generate the reflection vector depending on the initial direction of the object and the collision normal
        /// </summary>
        /// <param name="normal"> Collision normal </param>
        /// <param name="direction"> Direction of the current movement </param>
        /// <returns> Returns the reflected vector </returns>
        protected Vector2 ReflectionVector(Vector2 normal, Vector2 direction)
        {
            return direction - 2 * Vector2.Dot(normal, direction) * normal;
        }

        #endregion
    }
}
