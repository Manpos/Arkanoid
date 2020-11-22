using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GamePadInput : BaseInput
{
    // Start is called before the first frame update
    public override void Initialize()
    {
        _buttonCallbacks = new Dictionary<KeyCode, UnityEvent>()
        {
            [KeyCode.Joystick1Button2] = LeftButtonCallback,
            [KeyCode.LeftArrow] = LeftButtonCallback,
            
            [KeyCode.Joystick1Button1] = RightButtonCallback,
            [KeyCode.RightArrow] = RightButtonCallback,
            
            [KeyCode.Joystick1Button3] = UpButtonCallback,
            [KeyCode.UpArrow] = UpButtonCallback,
            
            [KeyCode.Joystick1Button0] = DownButtonCallback,
            [KeyCode.DownArrow] = DownButtonCallback,
            
            [KeyCode.Escape] = ResetButtonCallback, 
        };
    }
}
