using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;

    [SerializeField]
    private Player _player;
    
    [SerializeField]
    private Ball _ball;

    [SerializeField]
    private PhysicsManager _physicsManager;

    [SerializeField]
    private LowerTrigger _lowerTrigger;

    [SerializeField]
    private StatsCounter _statsCounter;

    [SerializeField]
    private SceneManager _sceneManager;
    
    private Vector3 _initialBallPosition;
    
    public Player Player => _player;
    public Ball Ball => _ball;

    private static GameManager _instance;
    
    public static GameManager Instance
    {
        get {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
             
                if (_instance == null)
                {
                    GameObject container = new GameObject("StatsCounter");
                    _instance = container.AddComponent<GameManager>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }
            return _instance;
        }
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null)
        {
            DontDestroyOnLoad(_instance.gameObject);
        }
        _initialBallPosition = _ball.transform.position;
        _lowerTrigger.SetResetPosition(_initialBallPosition);
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
}
