using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SendScore : UnityEvent<int> { }
public class BreakableBlock : MonoBehaviour, ICollide
{
    [SerializeField]
    private Image _blockImage;

    [SerializeField]
    private Collider2D _collider;

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

    private GameScene _gameScene;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameScene = GameManager.Instance.SceneManager.CurrentScene as GameScene;
        SetBlockParameters(_currentHits);
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
            _blockImage.enabled = false;
            _collider.enabled = false;
            SpawnPowerUp();
            StartCoroutine(DestroyBlock());
        }
    }

    private IEnumerator DestroyBlock()
    {
        yield return new WaitForSeconds(_particleTime);
        Destroy(transform.parent.gameObject);
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

    private void SpawnPowerUp()
    {
        PowerUp randomPowerUp = _gameScene.PowerUpsLibrary.GetRandomPowerUp();
        if (randomPowerUp != null)
        {
            Instantiate(randomPowerUp, transform.position, Quaternion.identity, _gameScene.CanvasTransform);
        }
    }
}
