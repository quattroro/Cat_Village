using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////////////////////////////////////////////////
/// 해당 인터페이스를 상속받는 모든 UI요소들은 
/// 마우스에 대해 PointerOverlay, PointerEnter, PointerOuter, PointerClick의 기능을 가진다.
/// UIManager에서 해당 인터페이스를 가지는 모든 요소들에 대해서 제어를 해준다.
///////////////////////////////////////////////////////////

public interface IUIPointer
{
    public bool IsActive
    {
        get;
        set;
    }

    public bool IsEnter
    {
        get;
        set;
    }


    public abstract void PointerOverlay();
    public abstract void PointerEnter();
    public abstract void PointerOuter();
    public abstract void PointerClick();

}
