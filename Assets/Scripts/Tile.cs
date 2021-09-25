using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject highlight;
    public bool hasBuilding;
    private bool isEnabled = false;

    // toggles the tile highlight to show where we can place a building
    public void ToggleHighlight(bool toggle)
    {
        highlight.SetActive(toggle);
        this.isEnabled = toggle;
    }

    // can this tile be highlighted based on a given position
    public bool CanBeHighlighted(Vector3 potentialPosition)
    {
        return transform.position == potentialPosition && !hasBuilding;
    }

    void OnMouseDown()
    {
        // place down a building on this tile
        if (GameManager.instance.placingBuilding && !hasBuilding && this.isEnabled){
           Map.instance.CreateNewBuilding(GameManager.instance.curSelectedBuilding, transform.position); 
        }
    }
}
