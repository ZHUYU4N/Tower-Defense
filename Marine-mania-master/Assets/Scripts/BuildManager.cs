using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject turretPrefab;
    public GameObject anotherPrefab;
    private TurretBluePrint turretToBuild;

    void Awake() {
        if (instance != null) {
            return;
        }
        instance = this;
    }
    
    public bool CanBuild { get {return turretToBuild != null;}}
    public bool HasGold { get {return GoldSystem.gold >= turretToBuild.cost;}}
    public void BuildTurret(Tile tile) {
        if (GoldSystem.gold < turretToBuild.cost) {
            Debug.Log("not enough money");
            return;
        }
        GoldSystem.gold -= turretToBuild.cost;
        GameObject turret = Instantiate(turretToBuild.prefab, tile.transform.position,Quaternion.identity);
        tile.turret = turret;
        Debug.Log("Current GOld:" + GoldSystem.gold);
    }
    public void SelectTurretToBuild(TurretBluePrint turret){
        turretToBuild = turret;
    }
}