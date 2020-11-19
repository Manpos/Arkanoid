using System;
using UnityEngine;

[Serializable]
public class BlockParameters
{
    [SerializeField]
    private int _breakingHits;

    [SerializeField]
    private Color _blockColor;

    public Color BlockColor => _blockColor;

    public int BreakingHits => _breakingHits;
}
