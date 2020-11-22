using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes
{
    public class EndScene : Scene
    {
        [SerializeField]
        private StatsCounter _statsCounter;

        [SerializeField]
        private TextMeshProUGUI _scoreDisplay;

        [SerializeField]
        private Button _replayButton;

        [SerializeField]
        private Button _exitButton;
    
        void Start()
        {
            _exitButton.onClick.AddListener(CloseGame);
            _replayButton.onClick.AddListener(Replay);
        }
    
        public override void LoadScene()
        {
            _scoreDisplay.text += _statsCounter.Score;
        }

        public override void UnloadScene()
        {
            _scoreDisplay.text = _scoreDisplay.text.Replace(_statsCounter.Score.ToString(), "");
        }
    
        private void CloseGame()
        {
            Application.Quit();
        }
    
        private void Replay()
        {
            OnNextScene.Invoke();
        }
    }
}
