using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScene : Scene
{
    [SerializeField]
    private Button _startButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
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
