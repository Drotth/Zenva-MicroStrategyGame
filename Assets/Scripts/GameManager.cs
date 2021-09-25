using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int curTurn;
    public bool placingBuilding;
    public BuildingType curSelectedBuilding;

    [Header("Current Resources")]
    public int curFood;
    public int curMetal;
    public int curOxygen;
    public int curEnergy;

    [Header("Round Resource Increase")]
    public int foodPerTurn;
    public int metalPerTurn;
    public int oxygenPerTurn;
    public int energyPerTurn;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // updating the UI
        UI.instance.UpdateResourcetext();
    }

    public void EndTurn()
    {
        // give resources
        curFood += foodPerTurn;
        curMetal += metalPerTurn;
        curOxygen += oxygenPerTurn;
        curEnergy += energyPerTurn;

        // update resource UI
        UI.instance.UpdateResourcetext();

        curTurn++;

        // enable building buttons
        UI.instance.ToggleBuildingButtons(true);

        // TODO enable usable tiles
    }

    //called when we click on a building button to place it
    public void SetPlacingBuilding(BuildingType buildingType)
    {
        placingBuilding = true;
        curSelectedBuilding = buildingType;
    }

    public void OnCreatedNewBuilding(Building building)
    {
        //resource the building may produce
        if (building.doesProduceResource)
        {
            switch (building.productionResource)
            {
                case ResourceType.Food:
                    foodPerTurn += building.productionResourcePerTurn;
                    break;
                case ResourceType.Metal:
                    metalPerTurn += building.productionResourcePerTurn;
                    break;
                case ResourceType.Oxygen:
                    oxygenPerTurn += building.productionResourcePerTurn;
                    break;
                case ResourceType.Energy:
                    energyPerTurn += building.productionResourcePerTurn;
                    break;
            }
        }

        //resource the building may cost
        if (building.hasMaintenanceCost)
        {
            switch (building.maintenanceResource)
            {
                case ResourceType.Food:
                    foodPerTurn -= building.maintenanceResourcePerTurn;
                    break;
                case ResourceType.Metal:
                    metalPerTurn -= building.maintenanceResourcePerTurn;
                    break;
                case ResourceType.Oxygen:
                    oxygenPerTurn -= building.maintenanceResourcePerTurn;
                    break;
                case ResourceType.Energy:
                    energyPerTurn -= building.maintenanceResourcePerTurn;
                    break;
            }
        }
        placingBuilding = false;

        // update the resource UI
        UI.instance.UpdateResourcetext();
    }
}
