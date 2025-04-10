using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public static Pathfinder Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Vector2Int> FindPath(Vector2Int start, Vector2Int target)
    {
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();
        queue.Enqueue(start);
        cameFrom[start] = start;

        Vector2Int[] directions = {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
        };

        while (queue.Count > 0)
        {
            Vector2Int current = queue.Dequeue();

            if (current == target)
                break;

            foreach (var dir in directions)
            {
                Vector2Int next = current + dir;
                if (IsInBounds(next) && !cameFrom.ContainsKey(next))
                {
                    queue.Enqueue(next);
                    cameFrom[next] = current;
                }
            }
        }

        if (!cameFrom.ContainsKey(target)) return null;

        List<Vector2Int> path = new List<Vector2Int>();
        Vector2Int step = target;
        while (step != start)
        {
            path.Add(step);
            step = cameFrom[step];
        }

        path.Reverse();
        return path;
    }

    bool IsInBounds(Vector2Int pos)
    {
        return pos.x >= 1 && pos.x <= 10 && pos.y >= 1 && pos.y <= 10;
    }
}

