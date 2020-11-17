using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateBall : PowerUp
{
    public override void OnPickedItem()
    {
        StartCoroutine(SecondBall(GameManager.Instance.Ball));
    }
    
    private IEnumerator SecondBall(Ball ball)
    {
        Ball newBall = Instantiate(ball, ball.transform.parent);
        yield return new WaitForSeconds(_timer);
    }
}
