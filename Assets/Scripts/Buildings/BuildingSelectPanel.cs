using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////////
/// 빌딩을 건설할때 건설할 빌딩을 선택하게 해줄 패널
/// 존재하는 모든 빌딩에 대하여 각각 해당하는 빌딩의 정보를 가지고 있는다.
/// 아직 언락되지 않은 빌딩의 경우에는 비활성화 되어 있는다.
///////////////////////////////////////////////////////////

public class BuildingSelectPanel : UIPointerAdapter
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
            return base.IsActive;
        }

        set
        {
            base.IsActive = value;
        }
    }

    public override void PointerClick()
    {

    }


    public override void PointerOverlay()
    {

    }
}
