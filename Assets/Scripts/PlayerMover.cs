using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public Vector2Int currentPos;

    private bool isMoving = false;

    void Start()
    {
        currentPos = new Vector2Int(1, 1); 
        transform.position = new Vector3(currentPos.x, 1f, currentPos.y);
    }


    void Update()
    {
        if (isMoving) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                TileInfo tile = hit.collider.GetComponent<TileInfo>();
                if (tile != null)
                {
                    Vector2Int targetPos = new Vector2Int(tile.x, tile.y);
                    StartCoroutine(MoveAlongPath(Pathfinder.Instance.FindPath(currentPos, targetPos)));
                }
            }
        }
    }

    IEnumerator MoveAlongPath(List<Vector2Int> path)
    {
        if (path == null) yield break;

        isMoving = true;

        foreach (Vector2Int step in path)
        {
            Vector3 targetWorldPos = new Vector3(step.x, 1f, step.y);
            while (Vector3.Distance(transform.position, targetWorldPos) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetWorldPos, Time.deltaTime * 5f);
                yield return null;
            }
            currentPos = step;
        }

        isMoving = false;

        FindObjectOfType<EnemyAI>()?.TakeTurn(currentPos);
    }
}
