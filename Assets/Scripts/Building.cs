using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    Base,
    greenhouse,
    Mine,
    SolarPanel
}

public enum ResourceType
{
    Food,
    Metal,
    Oxygen,
    Energy
}

public class Building : MonoBehaviour
{
    public BuildingType type;

    [Header("Production")]
    public bool doesProduceResource;
    public ResourceType productionResource;
    public int productionResourcePerTrun;

    [Header("Maintenance")]
    public bool hasMaintenaceCost;
    public ResourceType maintenanceResource;
    public int maintenanceResourcePerTurn;
}
