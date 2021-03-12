
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint basicTurret;
    public TurretBluePrint laserTurret;
    BuildManager buildManager;
    void Start() {
        buildManager = BuildManager.instance;
    }
    public void SelectBasicTurret()
    {
        Debug.Log("basic");
        buildManager.SelectTurretToBuild(basicTurret);
    }
     public void SelectLaserTurret()
    {
        Debug.Log("laser");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
