using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    [SerializeField]
    private Level _currentLevel;


    [SerializeField]
    private GameObject _levelTransition;

    private readonly WaitForSeconds _levelDelay = new WaitForSeconds(2f);
    
    private bool _changingLevel;
    private GameScene _gameScene;

    public bool ChangingLevel => _changingLevel;

    // Start is called before the first frame update
    void Start()
    {
        _currentLevel.OnNextLevel.AddListener(NextLevel);
        _gameScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
    }
    
    private void NextLevel()
    {
        _changingLevel = true;
        _levelTransition.SetActive(true);
        StartCoroutine(LevelTransition());
    }

    private void SetLevelProperties()
    {
        Level nextLevel = Instantiate(_currentLevel.NextLevel, _currentLevel.transform.parent);
        nextLevel.Parent.pivot = _currentLevel.Parent.pivot;
        nextLevel.Parent.anchorMax = _currentLevel.Parent.anchorMax;
        nextLevel.Parent.anchorMin = _currentLevel.Parent.anchorMin;
        nextLevel.Parent.anchoredPosition = _currentLevel.Parent.anchoredPosition;
        nextLevel.Parent.sizeDelta = _currentLevel.Parent.sizeDelta;
        Destroy(_currentLevel.gameObject);
        _currentLevel = nextLevel;
    }

    private IEnumerator LevelTransition()
    {
        _gameScene.DestroyAllBalls();
        _gameScene.ResetPlayer();
        _gameScene.DestroyPowerUps();
        yield return _levelDelay;
        SetLevelProperties();
        _levelTransition.SetActive(false);
        _changingLevel = false;
        _gameScene.InstantiateBall();
    }
}
