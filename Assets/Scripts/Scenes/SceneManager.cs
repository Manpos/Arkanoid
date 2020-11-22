using UnityEngine;

namespace Scenes
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField]
        private Scene _currentScene;

        public Scene CurrentScene => _currentScene;

        void Start()
        {
            _currentScene.LoadScene();
            _currentScene.OnNextScene.AddListener(NextScene);
        }
    
        private void NextScene()
        {
            Scene sceneHolder = _currentScene.NextScene;
            _currentScene.UnloadScene();
            _currentScene.OnNextScene.RemoveListener(NextScene);
            _currentScene.SceneContainer.SetActive(false);
            _currentScene = sceneHolder;
            _currentScene.SceneContainer.SetActive(true);
            _currentScene.LoadScene();
            _currentScene.OnNextScene.AddListener(NextScene);
        }
    
    }
}
