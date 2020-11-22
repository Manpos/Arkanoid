using UnityEngine.Events;

namespace Input
{
    public class InputCallBackAction
    {
        #region StandardAttributes

        private readonly UnityEvent _subscriptionEvent;

        private readonly UnityEvent _actionEvent;

        #endregion

        #region API Methods

        /// <summary>
        /// Establishes a link between an event and an Input action
        /// </summary>
        /// <param name="subscriptionEvent"> Event to execute when certain input is called </param>
        /// <param name="actionEvent"> Event called when the linked input is pressed </param>
        public InputCallBackAction(UnityEvent subscriptionEvent, UnityEvent actionEvent)
        {
            _subscriptionEvent = subscriptionEvent;
            _actionEvent = actionEvent;
        
            _subscriptionEvent.AddListener(actionEvent.Invoke);
        }

        /// <summary>
        /// Function to break the link between the established input-action events
        /// </summary>
        public void BreakLink()
        {
            _subscriptionEvent.RemoveListener(_actionEvent.Invoke);
        }

        #endregion
        
    }
}
