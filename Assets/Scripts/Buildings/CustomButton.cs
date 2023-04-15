using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;


public class CustomButton : UIPointerAdapter
{
    public UnityEvent ActionListener;

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
            IsStroke = value;
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

    public void AddListener(UnityAction action)
    {
        ActionListener.AddListener(action);
    }


    //Ŭ���Ǹ� �ش� ���� ��ü�� �����ؼ� ���忡 ��ġ�� �� �ֵ��� ���ش�.
    public override void OnPointerClick(PointerEventData eventData)
    {
        ActionListener.Invoke();

    }




    public override void OnPointerStay()
    {
        
    }
}
