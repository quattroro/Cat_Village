using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BUILDINGTYPE { NORMAL, ROAD, SPECIAL, BUILDINGTYPEMAX }

[System.Serializable]
public class BuildingInfo
{
    public string PrefabName;
    public string BuildingName;
    public int BuildingObjNum;
    public BUILDINGTYPE BuildingType;
    public Vector2Int BuildingSize;
    public int Price;
}
