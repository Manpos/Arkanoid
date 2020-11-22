using Scenes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SceneManager _sceneManager;

    private static GameManager _instance;
    
    public SceneManager SceneManager => _sceneManager;

    public static GameManager Instance
    {
        get {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
             
                if (_instance == null)
                {
                    GameObject container = new GameObject("GameManager");
                    _instance = container.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }
}
