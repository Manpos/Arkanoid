using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    
    public enum ControllerId
    {
        Player,
        PauseMenu
    }
    
    [SerializeField]
    private List<BaseInput> _inputs;

    private Dictionary<Controls.Control, UnityEvent> _controlActions;
    private Dictionary<ControllerId, Controller> _controllers;
    
    public UnityEvent OnLeftPressed;
    public UnityEvent OnRightPressed;
    public UnityEvent OnUpPressed;
    public UnityEvent OnDownPressed;
    
    public UnityEvent OnResetPressed;

    /// <summary>
    /// Current control schemes displayed (for the character, for the menu, etc)
    /// </summary>
    private Controller _currentController;

    private List<InputCallBackAction> _inputCallBackActions = new List<InputCallBackAction>();

    // Start is called before the first frame update
    void Start()
    {
        _controllers = new Dictionary<ControllerId, Controller>
        {
            [ControllerId.Player] = new PlayerController(),
            [ControllerId.PauseMenu] = new PauseController(),
        };
        
        _controlActions = new Dictionary<Controls.Control, UnityEvent>
        {
            [Controls.Control.Left] = OnLeftPressed,
            [Controls.Control.Right] = OnRightPressed,
            [Controls.Control.Up] = OnUpPressed,
            [Controls.Control.Down] = OnDownPressed,
            [Controls.Control.Reset] = OnResetPressed,
        };
        
        foreach (BaseInput input in _inputs)
        {
            input.Initialize();
        }
        
        SubscribeElements();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (BaseInput input in _inputs)
        {
            input.CheckPressedKeys();
        }
    }

    private void SubscribeElements()
    {
        int controlsLenght = Enum.GetNames(typeof(Controls.Control)).Length;
        
        foreach (BaseInput input in _inputs)
        {
            for (int i = 0; i < controlsLenght; i++)
            {
                _inputCallBackActions.Add(new InputCallBackAction(
                    input._controlsCallback[(Controls.Control) i] ,
                    _controlActions[(Controls.Control) i]));
            }
            
        }
    }
}
