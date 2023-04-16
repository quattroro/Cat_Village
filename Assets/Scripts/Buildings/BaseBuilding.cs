using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour
{
    


    /// 빌딩 정보
    public BuildingInfo buildingInfo;


    //자동 초기화
    private Transform SnapPoint;
    private BoxCollider boxCollider;


    public delegate void CustomEvent();
    private CustomEvent BuildingSetEvent;

    public void AddBuildingSetEvent(CustomEvent excute)
    {
        BuildingSetEvent += excute;
    }

    public void DeleteBuildingSetEvent(CustomEvent excute)
    {
        BuildingSetEvent -= excute;
    }


    public Vector3 GetSnapPoint
    {
        get
        {
            return SnapPoint.position;
        }
    }

    public Vector3Int GetSnapPointIndex
    {
        get
        {
            return new Vector3Int((int)SnapPoint.position.x / (int)MapManager.Instance.GridSize, 0, (int)SnapPoint.position.z / (int)MapManager.Instance.GridSize);
        }
    }

    private bool isSnaped;

    public bool IsSnaped
    {
        get
        {
            return isSnaped;
        }
        set
        {
            isSnaped = value;
        }
    }


    //[SerializeField]
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
            if (!isBluePrintMode)
                BuildingSetEvent();
        }
    }


    private void Start()
    {
        VirtualStart();
    }

    public virtual void VirtualStart()
    {
        InitSetting();
    }

    public void Update()
    {
        VirtualUpdate();
    }

    public virtual void VirtualUpdate()
    {
        if (IsBluePrintMode)
        {
            Snap();
        }
    }


    public void InitSetting()
    {
        boxCollider = GetComponent<BoxCollider>();
        SnapPoint = new GameObject("SnapPoint").transform;
        
        SnapPoint.parent = this.transform;
        SnapPoint.localPosition = new Vector3(-((boxCollider.size.x / 2) - boxCollider.center.x), -((boxCollider.size.y / 2) - boxCollider.center.y), -((boxCollider.size.z / 2) - boxCollider.center.z));

    }


    public void Snap()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 100,  /*LayerMask.NameToLayer("GridPlane")*/ MapManager.Instance.GridLayerMask);

        Vector3 worldMousePos = hit.point;



        if (hit.collider!=null)
        {
            //현재 마우스의 위치를 기준으로 잡은 가상의 스냅피봇의 위치 = 현재 마우스의 위치 + 스냅피봇의 로컬위치
            Vector3 tempSnapPoint = worldMousePos + (SnapPoint.position - this.transform.position);
            //temp1l.transform.position = tempSnapPoint;

            //해당 위치를 기준으로 왼쪽에 있는 월드 스냅피봇의 위치를 구한다.
            Vector3 worldSnapPoint = new Vector3((int)tempSnapPoint.x / (int)MapManager.Instance.GridSize, tempSnapPoint.y, (int)tempSnapPoint.z / (int)MapManager.Instance.GridSize);
            //temp2.transform.position = worldSnapPoint;

            //Grid의 시작점정보를 받아와서 스냅을 구현해준다.
            Vector3 tempvec = worldSnapPoint - tempSnapPoint;

            if (tempvec.sqrMagnitude < 0.5)
            {
                if(IsSnaped==false)
                {
                    
                }
                this.gameObject.transform.position = worldSnapPoint - (SnapPoint.position - this.transform.position);
                IsSnaped = true;
            }
            else
            {
                if(IsSnaped==true)
                {
                    
                }
                this.gameObject.transform.position = worldMousePos;
                IsSnaped = false;
            }
        }

    }

    

}
