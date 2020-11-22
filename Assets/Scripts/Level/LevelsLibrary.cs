using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelLibrary", order = 1)]
public class LevelsLibrary : ScriptableObject
{
    [SerializeField]
    private List<IndexedLevel> _indexedLevels;

    public List<IndexedLevel> IndexedLevels => _indexedLevels;
}
