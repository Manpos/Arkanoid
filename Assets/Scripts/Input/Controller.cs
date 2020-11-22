using UnityEngine;

namespace Input
{
    /// <summary>
    /// Class where all the input related actions must be introduced
    /// </summary>
    public abstract class Controller : MonoBehaviour
    {
        #region API Methods
        
        public abstract void Left();

        public abstract void Right();

        public abstract void Up();
    
        public abstract void Down();

        public abstract void ResetGame();
        
        #endregion
    }
}
