using UnityEngine;

namespace Level
{
    [System.Serializable]
    public class IndexedLevel
    {
        [SerializeField]
        private int _index;

        [SerializeField]
        private GameLevel _level;
        
        /// <summary>
        /// Index identifying the current level
        /// </summary>
        public int Index => _index;

        /// <summary>
        /// Reference to the actual level
        /// </summary>
        public GameLevel Level => _level;
    }
}
