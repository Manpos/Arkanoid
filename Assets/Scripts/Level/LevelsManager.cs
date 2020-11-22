using System.Collections;
using Scenes;
using UnityEngine;
using UnityEngine.Events;

namespace Level
{
    public class LevelsManager : MonoBehaviour
    {
        #region MyRegion
        /// <summary>
        /// Event called when the last level has been finished
        /// </summary>
        public UnityEvent OnLastLevel = new UnityEvent();

        #endregion

        #region SerializedField

        [SerializeField]
        private LevelsLibrary _levelsLibrary;
    
        [SerializeField]
        private GameLevel _currentLevel;
    
        [SerializeField]
        private GameObject _levelTransition;

        [SerializeField]
        private RectTransform _levelsParent;

        #endregion

        #region Standard Attributes

        /// <summary>
        /// Delay between levels
        /// </summary>
        private readonly WaitForSeconds _levelDelay = new WaitForSeconds(1.5f);
    
        /// <summary>
        /// Flag active between levels change
        /// </summary>
        private bool _changingLevel;
    
        /// <summary>
        /// Reference to the GameScene
        /// </summary>
        private GameScene _gameScene;

        #endregion
    
    
        /// <summary>
        /// Reference to the current loaded level
        /// </summary>
        public GameLevel CurrentLevel => _currentLevel;
    
        /// <summary>
        /// Reference to the ChangingLevel flag
        /// </summary>
        public bool ChangingLevel => _changingLevel;
    
        void Start()
        {
            InitializeLevelsManager();
        }
    
        /// <summary>
        /// Method executed when there is a level change
        /// </summary>
        private void ChangeLevel()
        {
            if (_currentLevel.NextLevelIndex == -1)
            {
                Destroy(_currentLevel.gameObject);
                OnLastLevel.Invoke();
                return;
            }

            if (_changingLevel) return;
        
            _changingLevel = true;
            _levelTransition.SetActive(true);
            StartCoroutine(LevelTransition());
        }

        /// <summary>
        /// Method used to set the next level properties and remove the current level
        /// </summary>
        private void SetNextLevelProperties()
        {
            GameLevel nextLevel = _levelsLibrary.IndexedLevels.Find(x => x.Index == _currentLevel.NextLevelIndex).Level;
            nextLevel = Instantiate(nextLevel, _levelsParent);
            Destroy(_currentLevel.gameObject);
            _currentLevel = nextLevel;
            _currentLevel.OnNextLevel.AddListener(ChangeLevel);
        }

        /// <summary>
        /// Coroutine executing a level change transition
        /// </summary>
        /// <returns></returns>
        private IEnumerator LevelTransition()
        {
            _gameScene.DestroyAllBalls();
            _gameScene.ResetPlayer();
            _gameScene.DestroyPowerUps();
            yield return _levelDelay;
            SetNextLevelProperties();
            _levelTransition.SetActive(false);
            _changingLevel = false;
            _gameScene.InstantiateBall();
        }

        /// <summary>
        /// Function to initialize the levels manager
        /// </summary>
        public void InitializeLevelsManager()
        {
            if (_currentLevel == null)
            {
                _currentLevel = Instantiate(_levelsLibrary.IndexedLevels[0].Level, _levelsParent);
            }
            _currentLevel.OnNextLevel.AddListener(ChangeLevel);
            _gameScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
        }
    }
}
