using System.Collections.Generic;

namespace PowerUps
{
    public class PowerUpsManager
    {
        private List<PowerUp> _activePowerUps = new List<PowerUp>();
    
        public void AddPowerUp(PowerUp powerUp)
        {
            PowerUp duplicatedPowerUp = _activePowerUps.Find(x => x.GetType() == powerUp.GetType());
            if (duplicatedPowerUp == null)
            {
                powerUp.OnPickedItem();
                _activePowerUps.Add(powerUp);
            }
            else
            {
                powerUp.DuplicatedPowerUp(duplicatedPowerUp);
                powerUp.DestroyPowerUp();
            }
        }

        public void RemovePowerUp(PowerUp powerUp)
        {
            _activePowerUps.Remove(powerUp);
            powerUp.DestroyPowerUp();
        }
    }
}
