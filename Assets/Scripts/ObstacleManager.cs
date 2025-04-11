using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleData obstacleData;
    public GameObject obstaclePrefab; 

    void Start()
    {
        for (int x = 1; x <= 10; x++)
        {
            for (int y = 1; y <= 10; y++)
            {
                int index = (y - 1) * 10 + (x - 1);
                if (obstacleData.obstacleMap[index])
                {
                    Instantiate(obstaclePrefab, new Vector3(x, 0.75f, y), Quaternion.identity);
                }
            }
        }
    }
}
