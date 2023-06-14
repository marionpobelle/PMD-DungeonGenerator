using System.ComponentModel.Design;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomFirstDungeonGenerator : AbstractDungeonGenerator
{

    [SerializeField]
    protected DungeonSO dungeonParameters;

    [SerializeField]
    protected MazeSO mazeParameters;

    //wa
    [SerializeField]
    protected SpecialSO specialParameters;

    [SerializeField]
    protected SpecialTerrainGenerator specialTerrainGenerator;  

    protected override void RunProceduralGeneration()
    {
        //wa
        specialTerrainGenerator = FindObjectOfType<SpecialTerrainGenerator>();
        CreateRooms(dungeonParameters, mazeParameters);
    }

    private void CreateRooms(DungeonSO dungeonParam, MazeSO mazeParam)
    {
        var roomsList = ProceduralGenerationAlgorithms.BinarySpacePartitioning(new BoundsInt((Vector3Int)startPosition, new Vector3Int(dungeonParam.dungeonWidth, dungeonParam.dungeonHeight, 0)), mazeParam.minRoomWidth, mazeParam.minRoomHeight);

        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        HashSet<Vector2Int> fill = new HashSet<Vector2Int>();
        HashSet<Vector2Int> dummies = new HashSet<Vector2Int>();
        HashSet<Vector2Int> special = new HashSet<Vector2Int>();
        
        HashSet<Vector2Int> specialPath = new HashSet<Vector2Int>();

        HashSet<Vector2Int> walls = new HashSet<Vector2Int>();

        floor = CreateSimpleRooms(mazeParameters, roomsList);
        fill = CreateDungeonBounds(new BoundsInt((Vector3Int)startPosition, new Vector3Int(dungeonParam.fillingWidth, dungeonParam.fillingHeight, 0)), 5);
        
        Vector2Int startPositionSpecial = new Vector2Int();
        for(int i=0; i< specialParameters.specialDensity; i++){
            startPositionSpecial = new Vector2Int(UnityEngine.Random.Range(1, dungeonParam.dungeonWidth), UnityEngine.Random.Range(1, dungeonParam.dungeonHeight));
            special.UnionWith(specialTerrainGenerator.CreateSpecialTerrain(startPositionSpecial, specialParameters));
        }
        
        Vector2Int startPositionPath = new Vector2Int();
        for(int i=0; i< specialParameters.erraticPath; i++){
            startPositionPath = new Vector2Int(UnityEngine.Random.Range(1, dungeonParam.dungeonWidth), UnityEngine.Random.Range(1, dungeonParam.dungeonHeight));
            specialPath.UnionWith(specialTerrainGenerator.CreateErraticPath(startPositionPath,  specialParameters));
        }
        special.UnionWith(specialPath);
        
        List<Vector2Int> outOfBoundSpecial = new List<Vector2Int>();
        foreach(Vector2Int pos in special){
            if(pos.x > dungeonParam.dungeonWidth || pos.x < 0)
            {
                outOfBoundSpecial.Add(pos);
            }
            else if(pos.y > dungeonParam.dungeonHeight || pos.y < 0)
            {
                outOfBoundSpecial.Add(pos);
            }
        }
        foreach(Vector2Int p in outOfBoundSpecial)
        {
            special.Remove(p);
        }
        List<Vector2Int> roomCenters = new List<Vector2Int>();
        List<Vector2Int> roomCentersToConnect = new List<Vector2Int>();
        foreach(var room in roomsList)
        {
            roomCenters.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
            roomCentersToConnect.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
        }
        HashSet<Vector2Int> corridors = ConnectRooms(roomCentersToConnect);

        dummies = CreateDummyRooms(mazeParameters, new BoundsInt((Vector3Int)startPosition, new Vector3Int(dungeonParam.dungeonWidth, dungeonParam.dungeonHeight, 0)), floor);
        floor.UnionWith(dummies);
        HashSet<Vector2Int> deadends = CreateDeadEnds(dummies, roomCenters);
        floor.UnionWith(corridors);
        floor.UnionWith(deadends);
        special.ExceptWith(floor);
        fill.ExceptWith(floor);
        fill.ExceptWith(special);
        tilemapVisualizer.PaintFillTiles(fill);
        tilemapVisualizer.PaintFloorTiles(floor);
        //wa
        walls = WallGenerator.FindWallsInDirections(floor, Direction2D.eightDirectionsList);
        walls.UnionWith(WallGenerator.FindWallsInDirections(special, Direction2D.eightDirectionsList));
        //special.ExceptWith(walls);
        walls.ExceptWith(special);
        //walls.UnionWith(fill);
        SpecialTerrainGenerator.CreateSpecialTiles(tilemapVisualizer, special, floor, walls);
        floor.UnionWith(special);
        WallGenerator.CreateWalls(floor, tilemapVisualizer);
    }

    private HashSet<Vector2Int> ConnectRooms(List<Vector2Int> roomCenters)
    {
        HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
        var currentRoomCenter = roomCenters[UnityEngine.Random.Range(0, roomCenters.Count)];
        roomCenters.Remove(currentRoomCenter);

        while(roomCenters.Count > 0)
        {
            Vector2Int closest = FindClosestPointTo(currentRoomCenter, roomCenters);
            roomCenters.Remove(closest);
            HashSet<Vector2Int> newCorridor = CreateCorridor(currentRoomCenter, closest);
            currentRoomCenter = closest;
            corridors.UnionWith(newCorridor);
            
        }
        return corridors;
    }

    private HashSet<Vector2Int> CreateDeadEnds(HashSet<Vector2Int> dummies, List<Vector2Int> roomCenters)
    {
        HashSet<Vector2Int> deadends = new HashSet<Vector2Int>();
        foreach(var dummy in dummies)
        {
            Vector2Int closest = FindClosestPointTo(dummy, roomCenters);
            deadends.UnionWith(CreateCorridor(dummy, closest));
        }
        return deadends;
    }

    private HashSet<Vector2Int> CreateCorridor(Vector2Int currentRoomCenter, Vector2Int destination)
    {
        HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
        var position = currentRoomCenter;
        corridor.Add(position);
        while(position.y != destination.y)
        {
            if(destination.y > position.y)
            {
                position += Vector2Int.up;
            }
            else if(destination.y < position.y)
            {
                position += Vector2Int.down;
            }
            corridor.Add(position);
        }
        while(position.x != destination.x)
        {
            if(destination.x > position.x)
            {
                position += Vector2Int.right;
            }
            else if(destination.x < position.x)
            {
                position += Vector2Int.left;
            }
            corridor.Add(position);
        }
        return corridor;
    }

    private Vector2Int FindClosestPointTo(Vector2Int currentRoomCenter, List<Vector2Int> roomCenters)
    {
        Vector2Int closest = Vector2Int.zero;
        float distance = float.MaxValue;
        foreach(var position in roomCenters)
        {
            float currentDistance = Vector2.Distance(position, currentRoomCenter);
            if(currentDistance < distance)
            {
                distance = currentDistance;
                closest = position;
            }
        }
        return closest;
    }

    private HashSet<Vector2Int> CreateSimpleRooms(MazeSO mazeParam, List<BoundsInt> roomsList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        foreach(var room in roomsList)
        {
            for(int col = mazeParam.offset; col < room.size.x - mazeParam.offset; col++)
            {
                for(int row = mazeParam.offset; row < room.size.y - mazeParam.offset; row++)
                {
                    Vector2Int position = (Vector2Int)room.min + new Vector2Int(col, row);
                    floor.Add(position);
                }
            }
        }
        return floor;
    }

    private HashSet<Vector2Int> CreateDummyRooms(MazeSO mazeParam, BoundsInt dungeonBounds, HashSet<Vector2Int> floor)
    {
        HashSet<Vector2Int> dummyRooms = new HashSet<Vector2Int>();
        int dummyCount = 0;
        while(dummyCount < mazeParam.deadendDensity)
            {
                Vector2Int position = new Vector2Int(UnityEngine.Random.Range(dungeonBounds.xMin, dungeonBounds.xMax + 1), UnityEngine.Random.Range(dungeonBounds.yMin, dungeonBounds.yMax + 1));
                if(floor.Contains(position) || floor.Contains(position +  new Vector2Int(1,0)) || floor.Contains(position +  new Vector2Int(-1,0)) || floor.Contains(position +  new Vector2Int(0,1)) || floor.Contains(position +  new Vector2Int(0,-1)))
                {
                    continue;
                }
                else
                {
                    dummyRooms.Add(position);
                    dummyCount++;
                }     
            }
        return dummyRooms;
    }

    private HashSet<Vector2Int> CreateDungeonBounds(BoundsInt filling, int fillOffset)
    {
        HashSet<Vector2Int> fill = new HashSet<Vector2Int>();
        for(int col = 0; col < filling.size.x; col++)
            {
                for(int row = 0; row < filling.size.y; row++)
                {
                    Vector2Int position = (Vector2Int)filling.min + new Vector2Int(col - fillOffset, row - fillOffset);
                    fill.Add(position);
                }
            }
        return fill;
    }

    
}
