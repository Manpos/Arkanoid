using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerUp : MonoBehaviour, IPickable
{
    [SerializeField]
    protected Image _powerUpImage;

    [SerializeField]
    protected Collider2D _collider;

    [SerializeField]
    protected float _timer;
    
    /// <summary>
    /// Spawn possibility rate on scale from 0 to 1
    /// </summary>
    [SerializeField]
    private float _spawnRate;

    public float SpawnRate => _spawnRate;
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void OnPickedItem();

    protected void OnCollisionEnter2D(Collision2D other)
    {
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _powerUpImage.enabled = false;
                _collider.enabled = false;
                OnPickedItem();
            }
        }
    }

}
