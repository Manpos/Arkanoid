using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Level
{
    public class GameLevel : MonoBehaviour
    {
        #region Events

        public UnityEvent OnNextLevel = new UnityEvent();

        #endregion

        #region SerializedFields

        /// <summary>
        /// Reference to the parent of the level
        /// </summary>
        [SerializeField]
        private RectTransform _parent;
    
        /// <summary>
        /// Reference to the parent containing all the destroyable blocks
        /// </summary>
        [SerializeField]
        private RectTransform _destroyableBlocksParent;

        /// <summary>
        /// Reference to the next level's index
        /// </summary>
        [SerializeField]
        private int _nextLevel;
        
        #endregion

        #region Consultors and Modifiers

        /// <summary>
        /// Index of the next level
        /// </summary>
        public int NextLevelIndex => _nextLevel;
        
        /// <summary>
        /// Reference of the level's parent
        /// </summary>
        public RectTransform Parent => _parent;

        #endregion

        #region API Methods

        private void Awake()
        {
            StartCoroutine(CheckFinishedLevel());
        }
    
        #endregion

        #region Other methods

        private IEnumerator CheckFinishedLevel()
        {
            yield return new WaitWhile( () => _destroyableBlocksParent.childCount > 0);
            OnNextLevel.Invoke();
        }
        
        #endregion
    }
}
