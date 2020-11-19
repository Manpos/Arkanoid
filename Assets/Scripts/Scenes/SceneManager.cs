using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private Scene _currentScene;

    public Scene CurrentScene => _currentScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(Scene nextScene)
    {
        _currentScene.UnloadScene();
        nextScene.LoadScene();
        _currentScene = nextScene;
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene.SceneId);
    }
}
