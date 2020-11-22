using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    
    // Start is called before the first frame update
    void Start()
    {
        _exitButton.onClick.AddListener(CloseGame);
        _replayButton.onClick.AddListener(Replay);
    }

    // Update is called once per frame
    void Update()
    {
        
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
