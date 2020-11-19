using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateBall : PowerUp
{
    public override void OnPickedItem()
    {
        GameScene currentScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
        StartCoroutine(SecondBall(currentScene.Ball));
    }

    protected override void OnResetPowerUp()
    {
        
    }

    public override void DuplicatedPowerUp(PowerUp previousPowerUp)
    {
        
    }

    private IEnumerator SecondBall(Ball ball)
    {
        Ball newBall = Instantiate(ball, ball.transform.parent);
        newBall.transform.position = ball.InitialPosition;
        newBall.AppliedForce(newBall.InitialDirection);
        yield return new WaitForSeconds(_maxTime);
    }
}
