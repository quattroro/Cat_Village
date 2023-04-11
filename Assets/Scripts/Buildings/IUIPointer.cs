using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////////////////////////////////////////////////
/// �ش� �������̽��� ��ӹ޴� ��� UI��ҵ��� 
/// ���콺�� ���� PointerOverlay, PointerEnter, PointerOuter, PointerClick�� ����� ������.
/// UIManager���� �ش� �������̽��� ������ ��� ��ҵ鿡 ���ؼ� ��� ���ش�.
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
