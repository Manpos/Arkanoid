using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Input
{
    public class GamePadInput : BaseInput
    {
        /// <summary>
        /// Link the joystick buttons to the callback events
        /// </summary>
        public override void Initialize()
        {
            _buttonCallbacks = new Dictionary<KeyCode, UnityEvent>()
            {
                [KeyCode.Joystick1Button2] = LeftButtonCallback,

                [KeyCode.Joystick1Button1] = RightButtonCallback,

                [KeyCode.Joystick1Button3] = UpButtonCallback,

                [KeyCode.Joystick1Button0] = DownButtonCallback,

                [KeyCode.Joystick1Button5] = ResetButtonCallback, 
            };
        }
    }
}
