using UnityEngine;
using UnityEngine.Events;

public class BallEnterEvent : UnityEvent<Ball> { }

public class LowerTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerActive;
    public BallEnterEvent OnBallEnter = new BallEnterEvent();
    private Vector3 _resetPosition;
    
    public void SetResetPosition(Vector3 resetPosition)
    {
        _resetPosition = resetPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ICollide>() != null && other.gameObject.CompareTag("Ball"))
        {
            OnTriggerActive.Invoke();
            Ball collidedBall = other.GetComponent<Ball>();
            OnBallEnter.Invoke(collidedBall);
        }

        if (other.gameObject.GetComponent<PowerUp>() != null)
        {
            Destroy(other.gameObject);
        }
    }

}
