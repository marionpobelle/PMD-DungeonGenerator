using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpecialTerrainGenerator : MonoBehaviour
{

    public HashSet<Vector2Int> CreateSpecialTerrain(Vector2Int startPosition, SpecialSO specialParameters){
        return RunRandomWalk(specialParameters, startPosition);
    }

    protected HashSet<Vector2Int> RunRandomWalk(SpecialSO parameters, Vector2Int position)
    {
        var currentPosition = position;
        HashSet<Vector2Int> specialPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, parameters.walkLength);
            specialPositions.UnionWith(path);
            if (parameters.startRandomlyEachIteration)
                currentPosition = specialPositions.ElementAt(Random.Range(0, specialPositions.Count));
        }
        return specialPositions;
    }

    public static void CreateSpecialTiles(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> specialPositions, HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> wallPositions)
    {
        foreach(var position in specialPositions)
        {
            string neighborsBinaryType = "";
            foreach(var direction in Direction2D.eightDirectionsList)
            {
                var neighborPosition = position + direction;
                if(floorPositions.Contains(neighborPosition))
                {
                    neighborsBinaryType += "0";
                }
                else if(wallPositions.Contains(neighborPosition))
                {
                    neighborsBinaryType += "0";
                }
                else
                {
                    neighborsBinaryType += "1";
                }
            }
            Debug.Log(neighborsBinaryType);
            tilemapVisualizer.PaintSpecialTerrain(position, neighborsBinaryType);
        }
    }

    public HashSet<Vector2Int> CreateErraticPath(Vector2Int startPosition, SpecialSO specialParameters)
    {
        HashSet<Vector2Int> specialPathPositions = new HashSet<Vector2Int>();
        var currentPosition = startPosition;
        specialPathPositions.Add((Vector2Int)currentPosition);
        for (int i = 0; i < specialParameters.pathCount; i++)
        {
            var path = ProceduralGenerationAlgorithms.RandomWalkCorridor(currentPosition, specialParameters.pathLength);
            specialPathPositions.UnionWith(path);
            currentPosition = path[path.Count - 1];
            specialPathPositions.Add(currentPosition);
        }
        return specialPathPositions;
    }

}