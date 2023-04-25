using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MazeParameters_",menuName = "PMD/MazeData")]
public class MazeSO : ScriptableObject
{
    
    [Tooltip("Amount of deadends")]
    public int deadendDensity = 5;

    [Tooltip("Minimum width of a room")]
    public int minRoomWidth = 10;

    [Tooltip("Minimum height of a room")]
    public int minRoomHeight = 10;

    [Tooltip("Offset between rooms")]
    [Range(0,10)]
    public int offset = 1;
}
