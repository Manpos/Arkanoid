using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerUp : MovingObject, IPickable
{
    [SerializeField]
    protected Image _powerUpImage;

    [SerializeField]
    protected Collider2D _collider;

    [SerializeField]
    protected float _maxTime;
    
    /// <summary>
    /// Spawn possibility rate on scale from 0 to 1
    /// </summary>
    [SerializeField]
    private float _spawnRate;

    private float _timeRemaining;

    private bool _activeTimer;

    private GameScene _gameScene;

    public float SpawnRate => _spawnRate;

    public abstract void OnPickedItem();

    protected abstract void OnResetPowerUp();

        private void Start()
    {
        _gameScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
        PhysicsManager.OnPhysics.AddListener(Movement);
    }

    private void Update()
    {
        AppliedForce(Vector2.down);
        if (_activeTimer) TimerUpdate();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _powerUpImage.enabled = false;
                _collider.enabled = false;
                
                SetUpTimer();
            }
        }
    }

    public virtual void DuplicatedPowerUp(PowerUp previousPowerUp)
    {
        DestroyPowerUp();
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

    public void DestroyPowerUp()
    {
        _gameScene.DestroyPowerUp(this);
    }

    public void UpdateTimerValue(float time)
    {
        _timeRemaining = time;
    }

}
