using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color hoverColor;
    public Color unableColor;

    private Renderer rend;

    [Header("Optional")]
    public GameObject turret;

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        buildManager = BuildManager.instance;
    }
    
    void OnMouseEnter()
    {
        if (!buildManager.CanBuild) {
            return;
        }
        if (buildManager.HasGold) {
            rend.material.color = hoverColor;
        } else {
            rend.material.color = unableColor;
        }
        rend.enabled = true;
    }

    void OnMouseExit()
    {
        rend.enabled = false;
    }

    void OnMouseDown() 
    {
        if (!buildManager.CanBuild) {
            return;
        }
        if (turret != null) {
            return;
        }
        buildManager.BuildTurret(this);
    }
}
