using Input;
using Level;
using Objects;
using UnityEngine;

public class PlayerController : Controller
{
    [SerializeField]
    private Player _player;

    [SerializeField]
    private InputManager _inputManager;

    [SerializeField]
    private LevelsManager _levelsManager;


    private void OnEnable()
    {
        _inputManager.OnLeftPressed.AddListener(Left);
        _inputManager.OnRightPressed.AddListener(Right);
        _inputManager.OnUpPressed.AddListener(Up);
        _inputManager.OnResetPressed.AddListener(ResetGame);
    }

    private void OnDisable()
    {
        _inputManager.OnLeftPressed.RemoveListener(Left);
        _inputManager.OnRightPressed.RemoveListener(Right);
        _inputManager.OnUpPressed.RemoveListener(Up);
        _inputManager.OnResetPressed.RemoveListener(ResetGame);
    }

    public override void Left()
    {
        if (!_player.LeftLimit)
        {
            _player.UpdateDirection(Vector2.left);
        }
    }

    public override void Right()
    {
        if (!_player.RightLimit)
        {
            _player.UpdateDirection(Vector2.right);
        }
    }

    public override void Up()
    {
        _levelsManager.CurrentLevel.OnNextLevel.Invoke();
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
