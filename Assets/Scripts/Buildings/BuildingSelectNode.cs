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

    public void InitSetting(BuildingInfo buildingInfo)
    {

    }


    //Ŭ���Ǹ� �ش� ���� ��ü�� �����ؼ� ���忡 ��ġ�� �� �ֵ��� ���ش�.
    public override void OnPointerClick(PointerEventData eventData)
    {

    }

    public override void OnPointerStay()
    {

    }
}
