using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelsManager : MonoBehaviour
{
    public UnityEvent OnLastLevel = new UnityEvent();

    [SerializeField]
    private LevelsLibrary _levelsLibrary;
    
    [SerializeField]
    private Level _currentLevel;
    
    [SerializeField]
    private GameObject _levelTransition;

    [SerializeField]
    private RectTransform _levelsParent;

    private readonly WaitForSeconds _levelDelay = new WaitForSeconds(2f);
    
    private bool _changingLevel;
    private GameScene _gameScene;

    public Level CurrentLevel => _currentLevel;

    public bool ChangingLevel => _changingLevel;
    
    void Start()
    {
        InitializeLevelsManager();
    }
    
    private void ChangeLevel()
    {
        if (_currentLevel.NextLevel == -1)
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

    private void SetNextLevelProperties()
    {
        Level nextLevel = _levelsLibrary.IndexedLevels.Find(x => x.Index == _currentLevel.NextLevel).Level;
        nextLevel = Instantiate(nextLevel, _levelsParent);
        Destroy(_currentLevel.gameObject);
        _currentLevel = nextLevel;
    }

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
