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

    void FixedUpdate(){
        
    }
}
