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
    private BoxCollider boxCollider;

    

    [SerializeField]
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


    public GameObject tempcube;
    public GameObject tempcube2;

    private void Start()
    {
        VirtualStart();
    }

    public virtual void VirtualStart()
    {
        InitSetting();
    }


    public void InitSetting()
    {
        boxCollider = GetComponent<BoxCollider>();
        SnapPoint = new GameObject("SnapPoint").transform;
        
        SnapPoint.parent = this.transform;
        SnapPoint.localPosition = new Vector3((boxCollider.size.x/2)+boxCollider.center.x, (boxCollider.size.y / 2)+boxCollider.center.y, 0);


    }


    public void Snap()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 100,  /*LayerMask.NameToLayer("GridPlane")*/ MapManager.Instance.GridLayerMask);

        Vector3 worldMousePos = hit.point;



        if (hit.collider!=null)
        {
            //현재 마우스의 위치에서 가상의 스냅피봇의 위치 = 현재 마우스의 위치 + 스냅피봇의 로컬위치
            //Vector3 tempSnapPoint = worldMousePos + new Vector3(SnapPoint.localPosition.x, worldMousePos.y, SnapPoint.localPosition.z);

            Vector3 tempSnapPoint = worldMousePos + (SnapPoint.position - this.transform.position);
            tempcube.transform.position = tempSnapPoint;

            //해당 위치를 기준으로 왼쪽에 있는 월드 스냅피봇의 위치를 구한다.
            Vector3 worldSnapPoint = new Vector3((int)tempSnapPoint.x / (int)MapManager.Instance.GridSize, tempSnapPoint.y, (int)tempSnapPoint.z / (int)MapManager.Instance.GridSize);
            tempcube2.transform.position = worldSnapPoint;

            //Grid의 시작점정보를 받아와서 스냅을 구현해준다.


            Vector3 tempvec = worldSnapPoint - tempSnapPoint;

            if (tempvec.sqrMagnitude < 0.5)
            {
                this.gameObject.transform.position = worldSnapPoint - (SnapPoint.position - this.transform.position);
            }
            else
            {
                this.gameObject.transform.position = worldMousePos;
            }
        }

        

    }

    public void Update()
    {
        if (IsBluePrintMode)
        {
            Snap();
        }
            
    }

}
