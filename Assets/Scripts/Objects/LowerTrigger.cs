using PowerUps;
using Scenes;
using UnityEngine;
using UnityEngine.Events;

namespace Objects {
    public class BallEnterEvent : UnityEvent<Ball> { }

    public class LowerTrigger : MonoBehaviour
    {
        #region Events
        
        public UnityEvent OnTriggerActive;
        public BallEnterEvent OnBallEnter = new BallEnterEvent();

        #endregion

        #region Other methods

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
                GameScene gameScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
                gameScene.PowerUpsManager.RemovePowerUp(other.gameObject.GetComponent<PowerUp>());
            }
        }

        #endregion
    }
}