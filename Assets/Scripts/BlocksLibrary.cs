using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BlocksLibrary", order = 1)]
public class BlocksLibrary : ScriptableObject
{
    [SerializeField]
    private List<BlockParameters> _blocksParameters;

    public List<BlockParameters> BlocksParameters => _blocksParameters;
}
