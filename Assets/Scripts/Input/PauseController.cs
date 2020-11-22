using UnityEngine;

public class PauseController : Controller
{

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
        
    }

    public override void Right()
    {
        
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
