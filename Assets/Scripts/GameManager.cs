using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
