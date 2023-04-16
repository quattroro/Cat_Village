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

    public override bool IsStroke
    {
        get
        {
            return base.IsStroke;
        }

        set
        {
            base.IsStroke = value;
        }
    }

    public void InitSetting(BuildingInfo buildingInfo)
    {

    }


    //Ŭ���Ǹ� �ش� ���� ��ü�� �����ؼ� ���忡 ��ġ�� �� �ֵ��� ���ش�.
    public override void OnPointerClick(PointerEventData eventData)
    {
        if(IsStroke)
        {
            IsStroke = false;
            MapManager.Instance.BuildCancel();
        }
        else
        {
            IsStroke = true;
            GameObject building = ResourcesManager.Instance.InstantiateObj<GameObject>(BuildingInfo.PrefabName, false);
            building.GetComponent<BaseBuilding>().buildingInfo = this.BuildingInfo;
            building.GetComponent<BaseBuilding>().AddBuildingSetEvent(UIReset);
            MapManager.Instance.BuildingBuild(building.GetComponent<BaseBuilding>());
        }

        
    }


    

    public override void OnPointerStay()
    {

    }
}
