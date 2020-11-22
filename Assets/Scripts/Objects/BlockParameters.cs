using System;
using UnityEngine;

namespace Objects
{
    [Serializable]
    public class BlockParameters
    {
        #region Serialized Fields

        [SerializeField]
        private int _breakingHits;

        [SerializeField]
        private Color _blockColor;

        #endregion

        #region Consultors

        /// <summary>
        /// Number if hits to be destroyed
        /// </summary>
        public int BreakingHits => _breakingHits;
        
        /// <summary>
        /// Color of the block
        /// </summary>
        public Color BlockColor => _blockColor;

        #endregion
    }
}
