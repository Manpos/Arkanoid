using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SendScore : UnityEvent<int>
{
    
}
public class BreakableBlock : MonoBehaviour, ICollide
{
    [SerializeField]
    private Image _blockImage;

    [SerializeField]
    private int _currentHits;

    [SerializeField]
    private BlocksLibrary _blocksLibrary;

    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private int _blockScore = 300;

    private float _particleTime = 2f;

    private SendScore OnBlockBroken = new SendScore();
    
    // Start is called before the first frame update
    void Start()
    {
        SetBlockParameters(_currentHits);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        OnBlockBroken.AddListener(StatsCounter.Instance.IncreaseScoreCounter);
    }
    
    private void OnDisable()
    {
        OnBlockBroken.RemoveListener(StatsCounter.Instance.IncreaseScoreCounter);
    }

    public void Collision(Vector2 normal)
    {
        _currentHits--;
        SetBlockParameters(_currentHits);
        if (_currentHits == 0)
        {
            _particleSystem.Play();
            OnBlockBroken.Invoke(_blockScore);
            _blockImage.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<ICollide>() != null && other.gameObject.CompareTag("Ball"))
        {
            Collision(other.GetContact(0).normal);
        }
    }

    private void SetBlockParameters(int remainingHits)
    {
        BlockParameters blockParameters = _blocksLibrary.BlocksParameters.Find(x=> x.BreakingHits == remainingHits);
        _blockImage.color = blockParameters.BlockColor;
    }
}
