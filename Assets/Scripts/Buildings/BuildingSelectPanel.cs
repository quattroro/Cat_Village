using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////////
/// ������ �Ǽ��Ҷ� �Ǽ��� ������ �����ϰ� ���� �г�
/// �����ϴ� ��� ������ ���Ͽ� ���� �ش��ϴ� ������ ������ ������ �ִ´�.
/// ���� ������� ���� ������ ��쿡�� ��Ȱ��ȭ �Ǿ� �ִ´�.
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
