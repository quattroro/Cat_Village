using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour
{
    public enum BUILDINGTYPE { NORMAL, BUILDINGTYPEMAX}

    public class BuildingInfo
    {
        public string BuildingName;
        public int BuildingObjNum;
        public int BuildingType;
                

    

    }



    public Transform SnapPoint;
    public float BuildNodeSize;

    private bool isBluePrintMode;

    public bool IsBluePrintMode
    {
        get
        {
            return isBluePrintMode;
        }
        set
        {
            isBluePrintMode = value;
        }
    }

    


    public void Snap(Vector3 snappos)
    {
        //Grid의 시작점정보를 받아와서 스냅을 구현해준다.
        Vector3 snapPoint = new Vector3(this.SnapPoint.position.x / MapManager.Instance.GridSize, this.SnapPoint.position.y, this.SnapPoint.position.z / MapManager.Instance.GridSize);

        Vector3 tempvec = this.SnapPoint.position - snapPoint;

        if (tempvec.sqrMagnitude < 1)
        {

        }
    }

    public void Update()
    {
                
    }

}
