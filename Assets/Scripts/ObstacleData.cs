using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObjects/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public bool[] obstacleMap = new bool[100]; // 10x10 grid (1D array)
}
