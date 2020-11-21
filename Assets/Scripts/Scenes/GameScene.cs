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

    [SerializeField]
    private List<Ball> _instancedBalls = new List<Ball>();

    #endregion

    #region Consultors

    public PowerUpsLibrary PowerUpsLibrary => _powerUpsLibrary;
    public PowerUpsManager PowerUpsManager { get; } = new PowerUpsManager();
    public RectTransform CanvasTransform => _canvasTransform;
    
    public Player Player => _player;
    public Ball BallPrefab => _ballPrefab;

    #endregion
    
    
    // Start is called before the first frame update
    void Start()
    {
        InstantiateBall();
        _lowerTrigger.OnBallEnter.AddListener(ResetBall);
    }

    // Update is called once per frame
    void Update()
    {
        if (_statsCounter.Lives <= 0 || _levelsManager.ChangingLevel) return;
        _physicsManager.UpdatePhysics();
    }

    public override void LoadScene()
    {
        _lowerTrigger.SetResetPosition(_ballPrefab.InitialPosition);
    }

    public override void UnloadScene()
    {
        
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
    
}
