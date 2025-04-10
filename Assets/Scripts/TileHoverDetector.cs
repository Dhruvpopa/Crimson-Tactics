using UnityEngine;
using TMPro;

public class TileHoverDetector : MonoBehaviour
{
    public TextMeshProUGUI tileInfoTMP; 

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            TileInfo info = hit.collider.GetComponent<TileInfo>();
            if (info != null)
            {
                tileInfoTMP.text = $"Tile: ({info.x}, {info.y})";
            }
        }
        else
        {
            tileInfoTMP.text = "";
        }
    }
}
