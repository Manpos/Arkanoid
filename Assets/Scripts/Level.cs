using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public UnityEvent OnNextLevel = new UnityEvent();
    
    [SerializeField]
    private RectTransform _parent;
    
    [SerializeField]
    private RectTransform _destroyableBlocksParent;

    [SerializeField]
    private Level _nextLevel;

    public Level NextLevel => _nextLevel;

    public RectTransform Parent => _parent;

    private void Awake()
    {
        StartCoroutine(CheckFinishedLevel());
    }
    
    private IEnumerator CheckFinishedLevel()
    {
        yield return new WaitWhile( () => _destroyableBlocksParent.childCount > 0);
        OnNextLevel.Invoke();
    }
}
