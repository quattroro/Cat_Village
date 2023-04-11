using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



///////////////////////////////////////////////////////////
/// JAVA�� AdapterŬ���� ó�� ��� IUIPointer�������̽��� ��ӹ޴�
/// Ŭ�������� ���������� ���Ǵ� ��ɵ��� ���� ���� ������ �ʵ��� ���ش�.
///////////////////////////////////////////////////////////
public class UIPointerAdapter : MonoBehaviour, IUIPointer
{
    public Image BackGround;


    //Stroke����� ��� UI���� �������� ����ϱ� ������ �⺻������ �������ش�.
    private void Awake()
    {
        GameObject temp = new GameObject("BackGround");
        temp.AddComponent<Image>();
        temp.transform.position = this.transform.position;
        temp.transform.parent = this.transform;
        temp.GetComponent<RectTransform>().sizeDelta = this.GetComponent<RectTransform>().sizeDelta * 1.05f;
        temp.transform.SetAsFirstSibling();


        BackGround = temp.GetComponent<Image>();
        BackGround.color = Color.red;

        BackGround.gameObject.SetActive(false);

    }

    [SerializeField]
    private bool isActive;

    public virtual bool IsActive
    {
        get
        {
            return isActive;
        }
        set
        {
            isActive = value;

        }
    }



    [SerializeField]
    private bool isEnter;

    public virtual bool IsEnter
    {
        get
        {
            return isEnter;
        }
        set
        {
            isEnter = value;

            if(value)
            {
                BackGround.gameObject.SetActive(true);
            }
            else
            {
                BackGround.gameObject.SetActive(false);
            }
        }
    }



    public virtual void PointerClick()
    {

    }

    public virtual void PointerEnter()
    {
        IsEnter = true;
    }

    public virtual void PointerOuter()
    {
        IsEnter = false;
    }

    public virtual void PointerOverlay()
    {

    }


}