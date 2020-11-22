using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    /// <summary>
    /// Library containing all the available levels for them to be Instanced 
    /// </summary>
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelLibrary", order = 1)]
    public class LevelsLibrary : ScriptableObject
    {
        [SerializeField]
        private List<IndexedLevel> _indexedLevels;

        public List<IndexedLevel> IndexedLevels => _indexedLevels;
    }
}
