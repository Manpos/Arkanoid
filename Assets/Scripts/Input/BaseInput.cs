using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseInput : MonoBehaviour
{
    protected Dictionary<KeyCode, UnityEvent> _buttonCallbacks;

    protected UnityEvent LeftButtonCallback = new UnityEvent();
    protected UnityEvent RightButtonCallback = new UnityEvent();
    protected UnityEvent UpButtonCallback = new UnityEvent();
    protected UnityEvent DownButtonCallback = new UnityEvent();

    protected UnityEvent ResetButtonCallback = new UnityEvent();
    
    public Dictionary<Controls.Control, UnityEvent> _controlsCallback;
    
    

    public void CheckPressedKeys()
    {
        foreach (KeyCode key in _buttonCallbacks.Keys)
        {
            if (Input.GetKey(key))
            {
                _buttonCallbacks[key].Invoke();
            }
        }
    }

    private void Awake()
    {
        _controlsCallback = new Dictionary<Controls.Control, UnityEvent>
        {
            [Controls.Control.Left] = LeftButtonCallback,
            [Controls.Control.Right] = RightButtonCallback,
            [Controls.Control.Up] = UpButtonCallback,
            [Controls.Control.Down] = DownButtonCallback,
            [Controls.Control.Reset] = ResetButtonCallback,
        };
    }

    public abstract void Initialize();
}
