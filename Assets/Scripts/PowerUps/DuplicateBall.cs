using Scenes;

namespace PowerUps
{
    public class DuplicateBall : PowerUp
    {
        public override void OnPickedItem()
        {
            _gameScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
            SecondBall();
        }

        protected override void OnResetPowerUp() { }

        public override void DuplicatedPowerUp(PowerUp previousPowerUp) { }

        private void SecondBall()
        {
            _gameScene.InstantiateBall();
            _gameScene.PowerUpsManager.RemovePowerUp(this);
        }
    }
}
