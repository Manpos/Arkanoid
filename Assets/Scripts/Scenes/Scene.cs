using UnityEngine;
using UnityEngine.Events;

public abstract class Scene : MonoBehaviour
{
    public UnityEvent OnNextScene = new UnityEvent();
    
    [SerializeField]
    protected Scene _nextScene;
    
    [SerializeField]
    protected GameObject _sceneContainer;

    public GameObject SceneContainer => _sceneContainer;
    
    public Scene NextScene => _nextScene;
    
    public abstract void LoadScene();
    public abstract void UnloadScene();
    
}
