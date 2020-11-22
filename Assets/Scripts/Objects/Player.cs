using Physics;
using UnityEngine;

namespace Objects
{
    public class Player : MovingObject, ICollide
    {
        #region Serialized Fields

        [SerializeField]
        private CapsuleCollider2D _capsule;

        [SerializeField]
        private EdgeCollider2D _edgeCollider;

        [SerializeField]
        private RectTransform _rectTransform;

        #endregion

        #region Consultors

        /// <summary>
        /// Reference to the capsule collider in the Player object
        /// </summary>
        public CapsuleCollider2D Capsule => _capsule;

        /// <summary>
        /// Reference to the edge collider in the Player object
        /// </summary>
        public EdgeCollider2D EdgeCollider => _edgeCollider;

        /// <summary>
        /// Rect transform of the player
        /// </summary>
        public RectTransform PlayerRectTransform => _rectTransform;

        /// <summary>
        /// Flag active when left limit of the screen reached
        /// </summary>
        public bool LeftLimit { get; private set; }
    
        /// <summary>
        /// Flag active when right limit of the screen reached
        /// </summary>
        public bool RightLimit { get; private set; }
        
        /// <summary>
        /// Player initial position
        /// </summary>
        public Vector3 InitialPosition { get; private set; } 

        #endregion

        #region API Methods

        private void Start()
        {
            PhysicsManager.OnPhysics.AddListener(Movement);
            InitialPosition = _rectTransform.position;
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

        public override void UpdateDirection(Vector2 direction)
        {
            if (_appliedForces.Count == 0)
            {
                _appliedForces.Enqueue(direction);
            }
        }

        #endregion

        #region Other Methods

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

        #endregion
    }
}
