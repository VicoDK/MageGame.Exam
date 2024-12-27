//AI

using UnityEngine;
using UnityEngine.Tilemaps;

public class IceMake : MonoBehaviour
{
    public GameObject icePrefab; // The prefab to instantiate at each tile
    public Tilemap tilemap; // Reference to the Tilemap component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InstantiateIceOnTiles();
    }

    void InstantiateIceOnTiles()
    {
        // Get the bounds of the tilemap
        BoundsInt bounds = tilemap.cellBounds;

        // Loop through each position in the bounds of the tilemap
        for (int x = bounds.x; x < bounds.xMax; x++)
        {
            for (int y = bounds.y; y < bounds.yMax; y++)
            {
                // Get the tile at the current position
                TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));

                // If there is a tile at this position, instantiate the ice prefab
                if (tile != null)
                {
                    // Calculate the world position of the tile
                    Vector3 worldPosition = tilemap.GetCellCenterWorld(new Vector3Int(x, y, 0));
                    // Instantiate the ice prefab at the tile's world position
                    Instantiate(icePrefab, worldPosition, Quaternion.identity, this.transform);
                }
            }
        }
    }
}