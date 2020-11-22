using System.Collections.Generic;
using Input;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardInput : BaseInput
{
    // Start is called before the first frame update
    public override void Initialize()
    {
        _buttonCallbacks = new Dictionary<KeyCode, UnityEvent>()
        {
            [KeyCode.A] = LeftButtonCallback,
            [KeyCode.LeftArrow] = LeftButtonCallback,
            
            [KeyCode.D] = RightButtonCallback,
            [KeyCode.RightArrow] = RightButtonCallback,
            
            [KeyCode.W] = UpButtonCallback,
            [KeyCode.UpArrow] = UpButtonCallback,
            
            [KeyCode.S] = DownButtonCallback,
            [KeyCode.DownArrow] = DownButtonCallback,
            
            [KeyCode.Escape] = ResetButtonCallback, 
        };
    }
}
