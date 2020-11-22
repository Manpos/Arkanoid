using System.Collections;
using PowerUps;
using Scenes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Objects {
    public class SendScore : UnityEvent<int> { }
    public class BreakableBlock : MonoBehaviour, ICollide
    {
        #region Events

        /// <summary>
        /// Event shot when the block is broken
        /// </summary>
        private SendScore OnBlockBroken = new SendScore();

        #endregion

        #region Serialized Fields

        /// <summary>
        /// Reference to the image of the block
        /// </summary>
        [SerializeField]
        private Image _blockImage;

        /// <summary>
        /// Reference to the collider of the block
        /// </summary>
        [SerializeField]
        private BoxCollider2D _collider;

        /// <summary>
        /// Reference to the amount of hits the block can handle
        /// </summary>
        [SerializeField]
        private int _currentHits;

        /// <summary>
        /// Library of possible blocks parameters
        /// </summary>
        [SerializeField]
        private BlocksLibrary _blocksLibrary;

        /// <summary>
        /// Reference to the particle system
        /// </summary>
        [SerializeField]
        private ParticleSystem _particleSystem;

        /// <summary>
        /// Score given by the broken block
        /// </summary>
        [SerializeField]
        private int _blockScore = 300;

        #endregion

        #region Standard Attributes

        private float _particleTime = 1.5f;

        private float _marginProportion = 0.98f;
        
        private GameScene _gameScene;

        #endregion

        #region API Methods
    
        void Start()
        {
            _gameScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
            SetBlockParameters(_currentHits);
            StartCoroutine(UpdateColliderSize());
        }

        private void OnEnable()
        {
            OnBlockBroken.AddListener(StatsCounter.Instance.IncreaseScoreCounter);
        }
    
        private void OnDisable()
        {
            OnBlockBroken.RemoveListener(StatsCounter.Instance.IncreaseScoreCounter);
        }

        public void Collision(Vector2 normal)
        {
            if(_currentHits == 0) return;
            _currentHits--;
            SetBlockParameters(_currentHits);
            if (_currentHits == 0)
            {
                _particleSystem.Play();
                OnBlockBroken.Invoke(_blockScore);
                _blockImage.enabled = false;
                _collider.enabled = false;
                SpawnPowerUp();
                StartCoroutine(DestroyBlock());
            }
        }

        #endregion

        #region Other Methods

        /// <summary>
        /// Destroy object after particleTime duration
        /// </summary>
        /// <returns></returns>
        private IEnumerator DestroyBlock()
        {
            yield return new WaitForSeconds(_particleTime);
            Destroy(transform.parent.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<ICollide>() != null && other.gameObject.CompareTag("Ball"))
            {
                Collision(other.GetContact(0).normal);
            }
        }

        /// <summary>
        /// Set blocks parameters depending on the remaining hits
        /// </summary>
        /// <param name="remainingHits"> Amount of hits to destroy the block </param>
        private void SetBlockParameters(int remainingHits)
        {
            BlockParameters blockParameters = _blocksLibrary.BlocksParameters.Find(x=> x.BreakingHits == remainingHits);
            _blockImage.color = blockParameters.BlockColor;
        }

        /// <summary>
        /// Spawn power up after breaking block
        /// </summary>
        private void SpawnPowerUp()
        {
            PowerUp randomPowerUp = _gameScene.PowerUpsLibrary.GetRandomPowerUp();
            if (randomPowerUp != null)
            {
                _gameScene.AddPowerUp(Instantiate(randomPowerUp, transform.position, Quaternion.identity, _gameScene.CanvasTransform));
            }
        }

        /// <summary>
        /// Update the collider size
        /// </summary>
        /// <returns></returns>
        private IEnumerator UpdateColliderSize()
        {
            yield return new WaitForEndOfFrame();
            _collider.size = _blockImage.rectTransform.rect.size * _marginProportion;
        }

        #endregion
    }
}