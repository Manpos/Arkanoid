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
    private TextMeshProUGUI _livesCounter;
    
    private Vector3 _initialBallPosition;
    
    // Start is called before the first frame update
    void Awake()
    {
        _initialBallPosition = _ball.transform.position;
        _lowerTrigger.SetResetPosition(_initialBallPosition);
    }

    // Update is called once per frame
    void Update()
    {
        _physicsManager.UpdatePhysics();
    }
}
