using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DungeonGeneratorParameters_", menuName = "PCG/DungeonGeneratorData")]
public class DungeonGeneratorData : ScriptableObject
{
    public int iterations = 10, walkLength = 10;
    public bool randomIterationStart = true;
}
