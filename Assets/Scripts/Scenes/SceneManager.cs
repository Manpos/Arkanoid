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
        _currentScene.LoadScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
