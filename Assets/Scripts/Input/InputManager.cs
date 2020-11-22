using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        /// <summary>
        /// Supported inputs
        /// </summary>
        private List<BaseInput> _inputs;

        private Dictionary<Controls.Control, UnityEvent> _controlActions;

        /// <summary>
        /// Event shoot when the Left button is pressed
        /// </summary>
        public UnityEvent OnLeftPressed;
        /// <summary>
        /// Event shoot when the Right button is pressed
        /// </summary>
        public UnityEvent OnRightPressed;
        /// <summary>
        /// Event shoot when the Up button is pressed
        /// </summary>
        public UnityEvent OnUpPressed;
        /// <summary>
        /// Event shoot when the Down button is pressed
        /// </summary>
        public UnityEvent OnDownPressed;
    
        /// <summary>
        /// Event shoot when the Reset button is pressed
        /// </summary>
        public UnityEvent OnResetPressed;

        /// <summary>
        /// Current control schemes used (for the character, for the menu, etc)
        /// </summary>
        private Controller _currentController;

        /// <summary>
        /// List containing the related inputs and events
        /// </summary>
        private readonly List<InputCallBackAction> _inputCallBackActions = new List<InputCallBackAction>();
        
        void Start()
        {
            _inputs = new List<BaseInput>()
            {
                new KeyboardInput(),
                new GamePadInput(),
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
                        input.ControlsCallback[(Controls.Control) i] ,
                        _controlActions[(Controls.Control) i]));
                }
            
            }
        }
    }
}
