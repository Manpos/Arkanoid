using Objects;
using Scenes;
using UnityEngine;

namespace PowerUps
{
    public class LargerPlayer : PowerUp
    {
        [SerializeField]
        private float _sizeMultiplier = 2;

        private Vector2 _colliderOriginalSize;
        private Vector2 _rectOriginalSize;

        private Player _player;
    
        public override void OnPickedItem()
        {
            GameScene currentScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
            EnlargePlayer(currentScene.Player);
        }

        protected override void OnResetPowerUp()
        {
            if (_player == null) return;
            _player.Capsule.size = _colliderOriginalSize;
            _player.PlayerRectTransform.sizeDelta = _rectOriginalSize;
            _player.Capsule.enabled = false;
            _player.EdgeCollider.enabled = true;
        }

        public override void DuplicatedPowerUp(PowerUp previousPowerUp)
        {
            previousPowerUp.UpdateTimerValue(_maxTime);
            base.DuplicatedPowerUp(previousPowerUp);
        }

        private void EnlargePlayer(Player player)
        {
            _player = player;
            _player.Capsule.enabled = true;
            _player.EdgeCollider.enabled = false;
            _colliderOriginalSize = player.Capsule.size;
            _rectOriginalSize = player.PlayerRectTransform.sizeDelta;
            player.Capsule.size = new Vector2(_colliderOriginalSize.x * _sizeMultiplier, _colliderOriginalSize.y);
            player.PlayerRectTransform.sizeDelta = new Vector2(_rectOriginalSize.x * _sizeMultiplier, _rectOriginalSize.y);
        }
    
    }
}
