using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour, AI
{
    public Vector2Int currentPos;
    private bool isMoving = false;

    void Start()
    {
        currentPos = new Vector2Int(10, 10); 
        transform.position = new Vector3(currentPos.x, 1f, currentPos.y);
    }

    public void TakeTurn(Vector2Int playerPos)
    {
        if (isMoving) return;

        List<Vector2Int> directions = new List<Vector2Int>{
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

        //for shuffling 
        /*for (int i = 0; i < directions.Count; i++)
        {
            var temp = directions[i];
            int randomIndex = Random.Range(i, directions.Count);
            directions[i] = directions[randomIndex];
            directions[randomIndex] = temp;
        }*/

        foreach (var dir in directions)
        {
            Vector2Int target = playerPos + dir;
            List<Vector2Int> path = Pathfinder.Instance.FindPath(currentPos, target);
            if (path != null)
            {
                StartCoroutine(MoveAlongPath(path));
                return;
            }
        }

    }

    IEnumerator MoveAlongPath(List<Vector2Int> path)
    {
        if (path == null) yield break;

        isMoving = true;

        foreach (Vector2Int step in path)
        {
            Vector3 worldPos = new Vector3(step.x, 1f, step.y);
            while (Vector3.Distance(transform.position, worldPos) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, worldPos, Time.deltaTime * 5f);
                yield return null;
            }
            currentPos = step;
        }

        isMoving = false;
    }
}
