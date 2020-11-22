using System;
using Objects;
using TMPro;
using UnityEngine;

public class StatsCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _livesCounter;

    [SerializeField]
    private TextMeshProUGUI _scoreCounter;

    [SerializeField]
    private LowerTrigger _lowerTrigger;
    
    [SerializeField]
    private int _lives;
    
    private int _score = 0;

    private int _initialLivesAmount;

    private static StatsCounter _instance;
    
    public int Lives => _lives;

    public int Score => _score;

    private void Awake()
    {
        _initialLivesAmount = _lives;
    }

    void Start()
    {
        _lowerTrigger.OnTriggerActive.AddListener(DecreaseLivesCounter);
    }
    
    public static StatsCounter Instance
    {
        get {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StatsCounter>();
             
                if (_instance == null)
                {
                    GameObject container = new GameObject("StatsCounter");
                    _instance = container.AddComponent<StatsCounter>();
                }
            }
            return _instance;
        }
    }

    private void DecreaseLivesCounter()
    {
        _livesCounter.text = _livesCounter.text.Replace(_lives.ToString(), "");
        _lives--;
        _livesCounter.text += _lives.ToString();
    }

    public void IncreaseScoreCounter(int score)
    {
        _scoreCounter.text = _scoreCounter.text.Replace(_score.ToString(), "");
        _score += score;
        _scoreCounter.text += _score.ToString();
    }

    public void ResetCounters()
    {
        _livesCounter.text = _livesCounter.text.Replace(_lives.ToString(), "");
        _lives = _initialLivesAmount;
        _livesCounter.text += _lives.ToString();
        
        _scoreCounter.text = _scoreCounter.text.Replace(_score.ToString(), "");
        _score = 0;
        _scoreCounter.text += _score.ToString();
    }
}
