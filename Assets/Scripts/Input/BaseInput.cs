using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Input
{
    public abstract class BaseInput
    {
        #region Events

        /// <summary>
        /// Event to be executed when the input linked to the Left action is pressed
        /// </summary>
        protected UnityEvent LeftButtonCallback = new UnityEvent();
        /// <summary>
        /// Event to be executed when the input linked to the Right action is pressed
        /// </summary>
        protected UnityEvent RightButtonCallback = new UnityEvent();
        /// <summary>
        /// Event to be executed when the input linked to the Up action is pressed
        /// </summary>
        protected UnityEvent UpButtonCallback = new UnityEvent();
        /// <summary>
        /// Event to be executed when the input linked to the Down action is pressed
        /// </summary>
        protected UnityEvent DownButtonCallback = new UnityEvent();

        /// <summary>
        /// Event to be executed when the input linked to the Reset action is pressed
        /// </summary>
        protected UnityEvent ResetButtonCallback = new UnityEvent();

        #endregion

        #region StandardAttributes
        
        /// <summary>
        /// Dictionary linking the unity keycode to a certain button callback
        /// </summary>
        protected Dictionary<KeyCode, UnityEvent> _buttonCallbacks;
        
        /// <summary>
        /// Dictionary linking the controls to the callbacks to be executed when pressing those controls
        /// </summary>
        private Dictionary<Controls.Control, UnityEvent> _controlsCallback;

        #endregion

        #region Consultors and Modifiers
    
        /// <summary>
        /// Dictionary linking the controls to the callbacks to be executed when pressing those controls
        /// </summary>
        public Dictionary<Controls.Control, UnityEvent> ControlsCallback => _controlsCallback;

        #endregion

        #region API Methods
        
        /// <summary>
        /// Function checking if any of the registered inputs has been pressed
        /// </summary>
        public void CheckPressedKeys()
        {
            foreach (KeyCode key in _buttonCallbacks.Keys)
            {
                if (UnityEngine.Input.GetKey(key))
                {
                    _buttonCallbacks[key].Invoke();
                }
            }
        }
        
        /// <summary>
        /// Function to initialize the input configurations for each input device
        /// </summary>
        public abstract void Initialize();

        protected BaseInput()
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
        #endregion
    }
}
