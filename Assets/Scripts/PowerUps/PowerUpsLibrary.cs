using System.Collections.Generic;
using PowerUps;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PowerUpsLibrary", order = 1)]
public class PowerUpsLibrary : ScriptableObject
{
    [SerializeField]
    private float _powerUpSpawnRate;

    [SerializeField]
    private List<PowerUp> _powerUps;

    public PowerUp GetRandomPowerUp()
    {
        if (!(Random.value <= _powerUpSpawnRate))
        {
            return null;
        }

        List<PowerUp> possiblePowerUps = _powerUps.FindAll(x => Random.value <= x.SpawnRate);
        return possiblePowerUps.Count > 0 ? possiblePowerUps[Random.Range(0, possiblePowerUps.Count)] : null;
    }
}
