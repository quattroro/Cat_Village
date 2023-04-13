using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSelectNode : UIPointerAdapter
{
    public BuildingInfo BuildingInfo;

    public override bool IsActive
    {
        get
        {
            return base.IsActive;
        }
        set
        {
            base.IsActive = value;
        }

    }

    public override bool IsEnter
    {
        get
        {
            return base.IsEnter;
        }

        set
        {
            base.IsEnter = value;
        }
    }

    public override bool IsStrock 
    {
        get
        {
            return base.IsStrock;
        }

        set
        {
            base.IsStrock = value;
        }
    }

    public void InitSetting(BuildingInfo buildingInfo)
    {

    }


    //클릭되면 해당 빌딩 객체를 생성해서 월드에 배치할 수 있도록 해준다.
    public override void OnPointerClick(PointerEventData eventData)
    {
        if(IsStrock)
        {
            IsStrock = false;
            MapManager.Instance.BuildCancel();
        }
        else
        {
            IsStrock = true;
            GameObject building = ResourcesManager.Instance.InstantiateObj<GameObject>(BuildingInfo.PrefabName, false);
            MapManager.Instance.BuildingBuild(building.GetComponent<BaseBuilding>());
        }

        
    }




    public override void OnPointerStay()
    {

    }
}
