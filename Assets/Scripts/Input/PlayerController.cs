using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private InputManager _inputManager;

    

    private void OnEnable()
    {
        _inputManager.OnLeftPressed.AddListener(Left);
        _inputManager.OnRightPressed.AddListener(Right);
        _inputManager.OnResetPressed.AddListener(ResetGame);
    }

    private void OnDisable()
    {
        _inputManager.OnLeftPressed.RemoveListener(Left);
        _inputManager.OnRightPressed.RemoveListener(Right);
        _inputManager.OnResetPressed.RemoveListener(ResetGame);
    }

    public override void Left()
    {
        if (!_player.LeftLimit)
        {
            _player.AppliedForce(Vector2.left);
        }
    }

    public override void Right()
    {
        if (!_player.RightLimit)
        {
            _player.AppliedForce(Vector2.right);
        }
    }

    public override void Up()
    {
        
    }

    public override void Down()
    {
        
    }

    public override void ResetGame()
    {
        UnityEngine.SceneManagement.Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene(); 
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
    }
    
}
