using UnityEngine;
using UnityEngine.UI;

namespace Scenes
{
    public class MenuScene : Scene
    {
        [SerializeField]
        private Button _startButton;
    
        public override void LoadScene()
        {
            _startButton.onClick.AddListener(ExecuteChangeScene);
        }

        public override void UnloadScene()
        {
            _startButton.onClick.RemoveListener(ExecuteChangeScene);
        }

        private void ExecuteChangeScene()
        {
            OnNextScene.Invoke();
        }
    }
}
