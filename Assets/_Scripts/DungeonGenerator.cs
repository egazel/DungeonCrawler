using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    protected DungeonGeneratorData dungeonGenerationData;

    protected override void GenerateProcedural()
    {
        HashSet<Vector2Int> floorPos = RunRandomWalk(dungeonGenerationData, startPos);
        tileMapVisualizer.Clear();
        tileMapVisualizer.PaintFloorTiles(floorPos);
        WallGenerator.CreateWalls(floorPos, tileMapVisualizer);
    }

    protected HashSet<Vector2Int> RunRandomWalk(DungeonGeneratorData parameters, Vector2Int pos)
    {
        var curPos = pos;
        HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = ProceduralGeneration.RandomWalk(curPos, parameters.walkLength);
            floorPos.UnionWith(path);
            if (parameters.randomIterationStart) {
                curPos = floorPos.ElementAt(Random.Range(0, floorPos.Count));
            }
        }
        return floorPos;
    }
}
