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


    //Ŭ���Ǹ� �ش� ���� ��ü�� �����ؼ� ���忡 ��ġ�� �� �ֵ��� ���ش�.
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
