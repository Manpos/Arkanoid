using System.Collections;
using Physics;
using Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace PowerUps
{
    public abstract class PowerUp : MovingObject, IPickable
    {
        #region Serialized Fields

        /// <summary>
        /// Power up image
        /// </summary>
        [SerializeField]
        protected Image _powerUpImage;

        /// <summary>
        /// Power up collider
        /// </summary>
        [SerializeField]
        protected Collider2D _collider;

        /// <summary>
        /// Elements displayed in the power up
        /// </summary>
        [SerializeField]
        protected GameObject _innerElements;

        /// <summary>
        /// Power up max time value
        /// </summary>
        [SerializeField]
        protected float _maxTime;
    
        /// <summary>
        /// Spawn possibility rate on scale from 0 to 1
        /// </summary>
        [SerializeField]
        private float _spawnRate;

        #endregion

        #region Standard Attributes

        private float _timeRemaining;

        private bool _activeTimer;

        protected GameScene _gameScene;

        #endregion

        #region Consultors

        public float SpawnRate => _spawnRate;

        #endregion

        #region API Methods
        
        public abstract void OnPickedItem();

        protected abstract void OnResetPowerUp();

        private void Start()
        {
            _gameScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
            PhysicsManager.OnPhysics.AddListener(Movement);
        }

        private void Update()
        {
            UpdateDirection(Vector2.down);
            if (_activeTimer) TimerUpdate();
        }
        
        public virtual void DuplicatedPowerUp(PowerUp previousPowerUp)
        {
            DestroyPowerUp();
        }

        public void DestroyPowerUp()
        {
            OnResetPowerUp();
            _gameScene.DestroyPowerUp(this);
        }

        public void UpdateTimerValue(float time)
        {
            _timeRemaining = time;
        }

        #endregion

        #region Other Methods

        protected void OnTriggerEnter2D(Collider2D other)
        {
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    _powerUpImage.enabled = false;
                    _collider.enabled = false;
                    _innerElements.SetActive(false);
                    SetUpTimer();
                }
            }
        }

        protected void TimerUpdate()
        {
            _timeRemaining -= Time.deltaTime;
        }

        private void SetUpTimer()
        {
            _gameScene.PowerUpsManager.AddPowerUp(this);
            _timeRemaining = _maxTime;
            _activeTimer = true;
            StartCoroutine(TimerEnd());
        }

        private IEnumerator TimerEnd()
        {
            yield return new WaitUntil(() => _timeRemaining <= 0f);
            _gameScene.PowerUpsManager.RemovePowerUp(this);
            OnResetPowerUp();
        }

        #endregion
    }
}
