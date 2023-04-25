using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="FluidParameters_",menuName = "PMD/FluidData")]
public class SpecialSO : ScriptableObject
{
    //FLUID
    [Tooltip("Amount of fluid areas")]
    public int specialDensity = 10;

    [Tooltip("Amount of fluid rivers")]
    public int erraticPath = 1;

    [Tooltip("Length of one portion of an erratic path")]
    public int pathLength = 14;
    
    [Tooltip("Amount of lines for an erratic path")]
    public int pathCount = 5;

    [Tooltip("Size of fluid area, amount of tiles, parameter for RandomWalk")]
    public int walkLength = 10;

    [Tooltip("Number of iterations, parameter for RandomWalk")]
    public int iterations = 10;
    public bool startRandomlyEachIteration = true;
}
