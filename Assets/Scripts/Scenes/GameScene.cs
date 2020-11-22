using System.Collections.Generic;
using UnityEngine;

public class GameScene : Scene
{
    #region Serializable Fields
    
    [SerializeField]
    private Player _player;
    
    [SerializeField]
    private Ball _ballPrefab;
    
    [SerializeField]
    private LowerTrigger _lowerTrigger;
    
    [SerializeField]
    private PhysicsManager _physicsManager;
    
    [SerializeField]
    private StatsCounter _statsCounter;

    [SerializeField]
    private PowerUpsLibrary _powerUpsLibrary;

    [SerializeField]
    private RectTransform _gameScreen;

    [SerializeField]
    private RectTransform _canvasTransform;

    [SerializeField]
    private LevelsManager _levelsManager;
    
    private readonly List<Ball> _instancedBalls = new List<Ball>();
    
    private readonly List<PowerUp> _instancedPowerUps = new List<PowerUp>();

    #endregion

    #region Consultors

    public StatsCounter StatsCounter => _statsCounter;
    public PowerUpsLibrary PowerUpsLibrary => _powerUpsLibrary;
    public PowerUpsManager PowerUpsManager { get; } = new PowerUpsManager();
    public RectTransform CanvasTransform => _canvasTransform;
    public Player Player => _player;

    #endregion
    
    
    // Start is called before the first frame update
    void Start()
    {
        _lowerTrigger.OnBallEnter.AddListener(ResetBall);
        _levelsManager.OnLastLevel.AddListener(OnNextScene.Invoke);
    }

    // Update is called once per frame
    void Update()
    {
        if (_levelsManager.ChangingLevel)
        {
            return;
        }

        if (_statsCounter.Lives <= 0)
        {
            Destroy(_levelsManager.CurrentLevel.gameObject);
            OnNextScene.Invoke();
        }
        _physicsManager.UpdatePhysics();
    }

    public override void LoadScene()
    {
        _levelsManager.InitializeLevelsManager();
        InstantiateBall();
        _lowerTrigger.SetResetPosition(_ballPrefab.InitialPosition);
        _statsCounter.ResetCounters();
    }

    public override void UnloadScene()
    {
        DestroyAllBalls();
        DestroyPowerUps();
        ResetPlayer();
    }

    public void DestroyBall(Ball ball)
    {
        _instancedBalls.Remove(ball);
        Destroy(ball.gameObject);
    }

    public void DestroyAllBalls()
    {
        foreach (Ball ball in _instancedBalls)
        {
            Destroy(ball.gameObject);
        }
        _instancedBalls.Clear();
    }

    public void InstantiateBall()
    {
        Ball newBall = Instantiate(_ballPrefab, _gameScreen);
        _instancedBalls.Add(newBall);
    }

    public void ResetBall(Ball ball)
    {
        DestroyBall(ball);
        if (_instancedBalls.Count > 0) return;
        InstantiateBall();
    }

    public void ResetPlayer()
    {
        _player.PlayerRectTransform.position = _player.InitialPosition;
    }

    public void AddPowerUp(PowerUp powerUp)
    {
        _instancedPowerUps.Add(powerUp);
    }

    public void DestroyPowerUp(PowerUp powerUp)
    {
        _instancedPowerUps.Remove(powerUp);
        Destroy(powerUp.gameObject);
    }

    public void DestroyPowerUps()
    {
        foreach (PowerUp powerUp in _instancedPowerUps)
        {
            Destroy(powerUp.gameObject);
        }
        _instancedPowerUps.Clear();
    }
}
