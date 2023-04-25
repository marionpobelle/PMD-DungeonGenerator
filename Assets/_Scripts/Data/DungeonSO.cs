using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DungeonParameters_",menuName = "PMD/DungeonData")]
public class DungeonSO : ScriptableObject
{
    //DUNGEON
    [Tooltip("Width of the dungeon")]
    public int dungeonWidth = 70;
    [Tooltip("Height of the dungeon")]
    public int dungeonHeight = 70;

    [Tooltip("Max x for the dungeon's border")]
    public int fillingWidth = 80;
    [Tooltip("Max y for the dungeon's border")]
    public int fillingHeight = 80;
}
