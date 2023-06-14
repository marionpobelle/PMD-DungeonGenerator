using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap, fillTilemap, specialTerrainTilemap;
    [SerializeField]
    private TileBase floorTile, wallTop, wallSideRight, wallSideLeft, wallBottom, wallFull,
    wallInnerCornerDownLeft, wallInnerCornerDownRight, wallInnerCornerUpLeft, wallInnerCornerUpRight,
    wallDiagonalCornerDownRight, wallDiagonalCornerDownLeft, wallDiagonalCornerUpRight, wallDiagonalCornerUpLeft, fillTile,
    //Water
    specialCornerUpLeft, specialCornerUpRight, specialCornerDownLeft, specialCornerDownRight,
    specialTop, specialBottom, specialLeft, specialRight, specialFull, specialSingle,
    specialLongHorizontal, specialLongVertical, specialLongCornerUpLeft, specialLongCornerUpRight, specialLongCornerDownLeft, specialLongCornerDownRight,
    specialLongEndTop, specialLongEndDown, specialLongEndLeft, specialLongEndRight, specialLongMiddle,
    specialTopInnerBottom, specialBottomInnerTop, specialLeftInnerRight, specialRightInnerLeft,
    specialInnerBottom, specialInnerTop, specialInnerLeft, specialInnerRight,
    specialInnerDownRight, specialInnerDownLeft, specialInnerUpLeft, specialInnerUpRight,
    specialLeftInnerDownRight, specialRightInnerUpLeft, specialBottomInnerUpRight, specialTopInnerDownLeft, specialLeftInnerUpRight,
    specialBottomInnerUpLeft, specialTopInnerDownRight, specialRightInnerDownLeft,
    specialInnerDiagUpLeft, specialInnerDiagUpRight, specialInnerDiagDownLeft, specialInnerDiagDownRight,
    specialDiagUpLeftDownRight, specialDiagDownLeftUpRight;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    public void PaintFillTiles(IEnumerable<Vector2Int> dungeonBounds)
    {
        PaintTiles(dungeonBounds, fillTilemap, fillTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    internal void PaintSingleBasicWall(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;
        if(WallByteTypes.wallTop.Contains(typeAsInt))
        {
            tile = wallTop;
        }
        else if(WallByteTypes.wallSideLeft.Contains(typeAsInt))
        {
            tile = wallSideLeft;
        }
        else if(WallByteTypes.wallSideRight.Contains(typeAsInt))
        {
            tile = wallSideRight;
        }
        else if(WallByteTypes.wallBottom.Contains(typeAsInt))
        {
            tile = wallBottom;
        }
        else if(WallByteTypes.wallFull.Contains(typeAsInt))
        {
            tile = wallFull;
        }
        if(tile != null)
        {
            PaintSingleTile(wallTilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
        fillTilemap.ClearAllTiles();
        specialTerrainTilemap.ClearAllTiles();
    }

    internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;

        if(WallByteTypes.wallInnerCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownLeft;
        }
        else if(WallByteTypes.wallInnerCornerDownRight.Contains(typeAsInt))
        {
            tile = wallInnerCornerDownRight;
        }
        else if(WallByteTypes.wallInnerCornerUpRight.Contains(typeAsInt))
        {
            tile = wallInnerCornerUpRight;
        }
        else if(WallByteTypes.wallInnerCornerUpLeft.Contains(typeAsInt))
        {
            tile = wallInnerCornerUpLeft;
        }
        else if(WallByteTypes.wallDiagonalCornerDownLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownLeft;
        }
        else if(WallByteTypes.wallDiagonalCornerDownRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerDownRight;
        }
        else if(WallByteTypes.wallDiagonalCornerUpRight.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpRight;
        }
        else if(WallByteTypes.wallDiagonalCornerUpLeft.Contains(typeAsInt))
        {
            tile = wallDiagonalCornerUpLeft;
        }
        else if(WallByteTypes.wallBottomEightDirections.Contains(typeAsInt))
        {
            tile = wallBottom;
        }
        else if(WallByteTypes.wallTopEightDirections.Contains(typeAsInt))
        {
            tile = wallTop;
        }
        else if(WallByteTypes.wallFullEightDirections.Contains(typeAsInt))
        {
            tile = wallFull;
        }
        else if(WallByteTypes.wallRightEightDirections.Contains(typeAsInt))
        {
            tile = wallSideRight;
        }
        else if(WallByteTypes.wallLeftEightDirections.Contains(typeAsInt))
        {
            tile = wallSideLeft;
        }

        if(tile != null)
        {
            PaintSingleTile(wallTilemap, tile, position);
        }
    }

    //Special paint

    internal void PaintSpecialTerrain(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2);
        TileBase tile = null;

        if(SpecialByteTypes.specialCornerUpLeft.Contains(typeAsInt))
        {
            tile = specialCornerUpLeft;
        }
        else if(SpecialByteTypes.specialCornerUpRight.Contains(typeAsInt))
        {
            tile = specialCornerUpRight;
        }
        else if(SpecialByteTypes.specialCornerDownLeft.Contains(typeAsInt))
        {
            tile = specialCornerDownLeft;
        }
        else if(SpecialByteTypes.specialCornerDownRight.Contains(typeAsInt))
        {
            tile = specialCornerDownRight;
        }
        //
        else if(SpecialByteTypes.specialTop.Contains(typeAsInt))
        {
            tile = specialTop;
        }
        else if(SpecialByteTypes.specialBottom.Contains(typeAsInt))
        {
            tile = specialBottom;
        }
        else if(SpecialByteTypes.specialLeft.Contains(typeAsInt))
        {
            tile = specialLeft;
        }
        else if(SpecialByteTypes.specialRight.Contains(typeAsInt))
        {
            tile = specialRight;
        }
        else if(SpecialByteTypes.specialFull.Contains(typeAsInt))
        {
            tile = specialFull;
        }
        else if(SpecialByteTypes.specialSingle.Contains(typeAsInt))
        {
            tile = specialSingle;
        }
        //
        else if(SpecialByteTypes.specialLongHorizontal.Contains(typeAsInt))
        {
            tile = specialLongHorizontal;
        }
        else if(SpecialByteTypes.specialLongVertical.Contains(typeAsInt))
        {
            tile = specialLongVertical;
        }
        //
        else if(SpecialByteTypes.specialLongCornerUpLeft.Contains(typeAsInt))
        {
            tile = specialLongCornerUpLeft;
        }
        else if(SpecialByteTypes.specialLongCornerUpRight.Contains(typeAsInt))
        {
            tile = specialLongCornerUpRight;
        }
        else if(SpecialByteTypes.specialLongCornerDownLeft.Contains(typeAsInt))
        {
            tile = specialLongCornerDownLeft;
        }
        else if(SpecialByteTypes.specialLongCornerDownRight.Contains(typeAsInt))
        {
            tile = specialLongCornerDownRight;
        }
        //
        else if(SpecialByteTypes.specialLongEndTop.Contains(typeAsInt))
        {
            tile = specialLongEndTop;
        }
        else if(SpecialByteTypes.specialLongEndDown.Contains(typeAsInt))
        {
            tile = specialLongEndDown;
        }
        else if(SpecialByteTypes.specialLongEndLeft.Contains(typeAsInt))
        {
            tile = specialLongEndLeft;
        }
        else if(SpecialByteTypes.specialLongEndRight.Contains(typeAsInt))
        {
            tile = specialLongEndRight;
        }
        else if(SpecialByteTypes.specialLongMiddle.Contains(typeAsInt))
        {
            tile = specialLongMiddle;
        }
        //
        else if(SpecialByteTypes.specialTopInnerBottom.Contains(typeAsInt))
        {
            tile = specialTopInnerBottom;
        }
        else if(SpecialByteTypes.specialBottomInnerTop.Contains(typeAsInt))
        {
            tile = specialBottomInnerTop;
        }
        else if(SpecialByteTypes.specialLeftInnerRight.Contains(typeAsInt))
        {
            tile = specialLeftInnerRight;
        }
        else if(SpecialByteTypes.specialRightInnerLeft.Contains(typeAsInt))
        {
            tile = specialRightInnerLeft;
        }
        //
        else if(SpecialByteTypes.specialInnerBottom.Contains(typeAsInt))
        {
            tile = specialInnerBottom;
        }
        else if(SpecialByteTypes.specialInnerTop.Contains(typeAsInt))
        {
            tile = specialInnerTop;
        }
        else if(SpecialByteTypes.specialInnerLeft.Contains(typeAsInt))
        {
            tile = specialInnerLeft;
        }
        else if(SpecialByteTypes.specialInnerRight.Contains(typeAsInt))
        {
            tile = specialInnerRight;
        }
        //
        else if(SpecialByteTypes.specialInnerDownRight.Contains(typeAsInt))
        {
            tile = specialInnerDownRight;
        }
        else if(SpecialByteTypes.specialInnerDownLeft.Contains(typeAsInt))
        {
            tile = specialInnerDownLeft;
        }
        else if(SpecialByteTypes.specialInnerUpLeft.Contains(typeAsInt))
        {
            tile = specialInnerUpLeft;
        }
        else if(SpecialByteTypes.specialInnerUpRight.Contains(typeAsInt))
        {
            tile = specialInnerUpRight;
        }
        //
        else if(SpecialByteTypes.specialLeftInnerDownRight.Contains(typeAsInt))
        {
            tile = specialLeftInnerDownRight;
        }
        else if(SpecialByteTypes.specialRightInnerUpLeft.Contains(typeAsInt))
        {
            tile = specialRightInnerUpLeft;
        }
        else if(SpecialByteTypes.specialBottomInnerUpRight.Contains(typeAsInt))
        {
            tile = specialBottomInnerUpRight;
        }
        else if(SpecialByteTypes.specialTopInnerDownLeft.Contains(typeAsInt))
        {
            tile = specialTopInnerDownLeft;
        }
        else if(SpecialByteTypes.specialLeftInnerUpRight.Contains(typeAsInt))
        {
            tile = specialLeftInnerUpRight;
        }
        else if(SpecialByteTypes.specialBottomInnerUpLeft.Contains(typeAsInt))
        {
            tile = specialBottomInnerUpLeft;
        }
        else if(SpecialByteTypes.specialTopInnerDownRight.Contains(typeAsInt))
        {
            tile = specialTopInnerDownRight;
        }
        else if(SpecialByteTypes.specialRightInnerDownLeft.Contains(typeAsInt))
        {
            tile = specialRightInnerDownLeft;
        }
        //
        else if(SpecialByteTypes.specialInnerDiagUpLeft.Contains(typeAsInt))
        {
            tile = specialInnerDiagUpLeft;
        }
        else if(SpecialByteTypes.specialInnerDiagUpRight.Contains(typeAsInt))
        {
            tile = specialInnerDiagUpRight;
        }
        else if(SpecialByteTypes.specialInnerDiagDownLeft.Contains(typeAsInt))
        {
            tile = specialInnerDiagDownLeft;
        }
        else if(SpecialByteTypes.specialInnerDiagDownRight.Contains(typeAsInt))
        {
            tile = specialInnerDiagDownRight;
        }
        //
        else if(SpecialByteTypes.specialDiagUpLeftDownRight.Contains(typeAsInt))
        {
            tile = specialDiagUpLeftDownRight;
        }
        else if(SpecialByteTypes.specialDiagDownLeftUpRight.Contains(typeAsInt))
        {
            tile = specialDiagDownLeftUpRight;
        }

        if(tile != null)
        {
            PaintSingleTile(specialTerrainTilemap, tile, position);
        }
    }
}
