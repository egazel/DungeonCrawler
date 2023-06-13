using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTileMap, wallTileMap;
    [SerializeField]
    private TileBase floorTile, wallTop;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTileMap, floorTile);
    }

    internal void PaintSingleBasicWall(Vector2Int pos)
    {
        PaintSingleTile(wallTileMap, wallTop, pos);
    }

    private void PaintTiles(IEnumerable<Vector2Int> posList, Tilemap tileMap, TileBase tile)
    {
        foreach (var pos in posList)
        {
            PaintSingleTile(tileMap, tile, pos);
        }
    }

    private void PaintSingleTile(Tilemap tileMap, TileBase tile, Vector2Int pos)
    {
        var tilePos = tileMap.WorldToCell((Vector3Int)pos);
        tileMap.SetTile(tilePos, tile);
    }

    public void Clear()
    {
        wallTileMap.ClearAllTiles();
        floorTileMap.ClearAllTiles();
    }
}
