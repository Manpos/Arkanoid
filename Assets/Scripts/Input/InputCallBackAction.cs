using UnityEngine.Events;

public class InputCallBackAction
{
    private UnityEvent _subscriptionEvent;

    private UnityEvent _actionEvent;

    public InputCallBackAction(UnityEvent subscriptionEvent, UnityEvent actionEvent)
    {
        _subscriptionEvent = subscriptionEvent;
        _actionEvent = actionEvent;
        
        _subscriptionEvent.AddListener(actionEvent.Invoke);
    }

    public void BreakLink()
    {
        _subscriptionEvent.RemoveListener(_actionEvent.Invoke);
    }
}
