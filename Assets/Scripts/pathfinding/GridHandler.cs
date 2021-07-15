
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridHandler : MonoBehaviour
{
    public Tilemap blueWalls;
    public Tilemap redWalls;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Grid " + this.blueWalls.cellBounds);
    }

    public Vector3 getTilePos(GameObject obj) {
        Vector3Int cell = this.blueWalls.WorldToCell(obj.transform.position);
        return this.blueWalls.GetCellCenterLocal(cell);
    }
}
