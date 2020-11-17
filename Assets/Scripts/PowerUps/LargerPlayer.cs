using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargerPlayer : PowerUp
{
    [SerializeField]
    private float _sizeMultiplier = 2;
    
    public override void OnPickedItem()
    {
        StartCoroutine(EnlargePlayer(GameManager.Instance.Player));
    }
    
    private IEnumerator EnlargePlayer(Player player)
    {
        Vector2 colliderOriginalSize = player.Capsule.size;
        Vector2 rectOriginalSize = player.PlayerRectTransform.sizeDelta;
        player.Capsule.size = new Vector2(colliderOriginalSize.x * _sizeMultiplier, colliderOriginalSize.y);
        player.PlayerRectTransform.sizeDelta = new Vector2(rectOriginalSize.x * _sizeMultiplier, rectOriginalSize.y);
        yield return new WaitForSeconds(_timer);
        player.Capsule.size = colliderOriginalSize;
        player.PlayerRectTransform.sizeDelta = rectOriginalSize;
    }
    
}
