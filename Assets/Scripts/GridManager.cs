using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public int width = 10;
    public int height = 10;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 1; x <= width; x++)
        {
            for (int y = 1; y <= height; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, 0, y), Quaternion.identity);
                tile.name = $"Tile {x},{y}";

                TileInfo info = tile.AddComponent<TileInfo>();
                info.x = x;
                info.y = y;
            }
        }
    }
}
