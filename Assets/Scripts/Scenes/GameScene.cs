using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : Scene
{
    #region Serializable Fields
    
    [SerializeField]
    private Player _player;
    
    [SerializeField]
    private Ball _ball;
    
    [SerializeField]
    private LowerTrigger _lowerTrigger;
    
    [SerializeField]
    private PhysicsManager _physicsManager;
    
    [SerializeField]
    private StatsCounter _statsCounter;

    [SerializeField]
    private PowerUpsLibrary _powerUpsLibrary;

    [SerializeField]
    private RectTransform _canvasTransform;

    public PowerUpsLibrary PowerUpsLibrary => _powerUpsLibrary;

    public PowerUpsManager PowerUpsManager { get; } = new PowerUpsManager();

    public RectTransform CanvasTransform => _canvasTransform;

    #endregion

    #region Consultors

    public Player Player => _player;
    public Ball Ball => _ball;

    #endregion
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_statsCounter.Lives <= 0)
        {
            Debug.Log("GAME OVER");
        }
        else
        {
            _physicsManager.UpdatePhysics();
        }
    }

    public override void LoadScene()
    {
        _lowerTrigger.SetResetPosition(_ball.InitialPosition);
    }

    public override void UnloadScene()
    {
        
    }
}
