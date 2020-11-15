using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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

    private static StatsCounter _instance;
    
    public int Lives => _lives;
    
    void Start()
    {
        _scoreCounter.text += "0";
        _livesCounter.text += _lives;
        _lowerTrigger.OnTriggerActive.AddListener(DecreaseLivesCounter);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
