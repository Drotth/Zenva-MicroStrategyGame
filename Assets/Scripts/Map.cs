using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<Tile> tiles = new List<Tile>();
    // all buildings currently spawned inside game
    public List<Building> buildings = new List<Building>();
    public float tileSize; // is 1 unit for now

    // prefabs in project window
    public List<Building> buildingPrefabs = new List<Building>();
    public static Map instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        EnableUsableTiles();
    }

    public void EnableUsableTiles()
    {
        foreach (Building building in buildings)
        {
            Tile northTile = GetTileAtPosition(building.transform.position + new Vector3(0, tileSize, 0));
            Tile southTile = GetTileAtPosition(building.transform.position + new Vector3(0, -tileSize, 0));
            Tile eastTile = GetTileAtPosition(building.transform.position + new Vector3(tileSize, 0, 0));
            Tile westTile = GetTileAtPosition(building.transform.position + new Vector3(-tileSize, 0, 0));

            northTile?.ToggleHighlight(true);
            southTile?.ToggleHighlight(true);
            eastTile?.ToggleHighlight(true);
            westTile?.ToggleHighlight(true);
        }
    }

    // returns the tile that's at the given position, if it can be highlighted. 
    // otherwise null.
    Tile GetTileAtPosition(Vector3 pos)
    {
        return tiles.Find(x => x.CanBeHighlighted(pos));
    }

    // disables the visual showing which tiles we can place a building on
    public void DisableUsableTiles()
    {
        foreach (Tile tile in tiles)
        {
            tile.ToggleHighlight(false);
        }
    }

    // creates a new building on a specific tile
    public void CreateNewBuilding(BuildingType type, Vector3 position)
    {
        Building prefabToSpawn = buildingPrefabs.Find(x => x.type == type);
        GameObject buildingObj = Instantiate(prefabToSpawn.gameObject, position, Quaternion.identity);
        buildings.Add(buildingObj.GetComponent<Building>());
        GetTileAtPosition(position).hasBuilding = true;
        DisableUsableTiles();
        GameManager.instance.OnCreatedNewBuilding(prefabToSpawn);
    }
}
