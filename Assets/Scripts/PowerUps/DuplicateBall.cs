using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateBall : PowerUp
{
    private GameScene _gameScene;
    public override void OnPickedItem()
    {
        _gameScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
        SecondBall();
    }

    protected override void OnResetPowerUp()
    {
        
    }

    public override void DuplicatedPowerUp(PowerUp previousPowerUp)
    {
        
    }

    private void SecondBall()
    {
        _gameScene.InstantiateBall();
        Destroy(gameObject);
    }
}
