using UnityEngine;

[System.Serializable]
public class IndexedLevel
{
    [SerializeField]
    private int _index;

    [SerializeField]
    private Level _level;
    
    public int Index => _index;

    public Level Level => _level;
}
