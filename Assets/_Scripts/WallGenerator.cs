using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPos, TileMapVisualizer tileMapVisualizer)
    {
        var basicWallsPos = FindWallsInDirections(floorPos, Direction2D.cardinalDirList);
        foreach (var pos in basicWallsPos)
        {
            tileMapVisualizer.PaintSingleBasicWall(pos);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPos, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPos = new HashSet<Vector2Int>();
        foreach (var pos in floorPos)
        {
            foreach (var dir in directionList)
            {
                var neighbourPos = pos + dir;
                if(floorPos.Contains(neighbourPos) == false)
                {
                    wallPos.Add(neighbourPos); 
                }
            }
        }
        return wallPos;
    }
}
