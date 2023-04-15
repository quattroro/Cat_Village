using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


///////////////////////////////////////////////////////////
/// JAVA�� AdapterŬ���� ó�� ��� IUIPointer�������̽��� ��ӹ޴�
/// Ŭ�������� ���������� ���Ǵ� ��ɵ��� ���� ���� ������ �ʵ��� ���ش�.
///////////////////////////////////////////////////////////
public class UIPointerAdapter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
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
        }
    }



    private bool isStroke;

    public virtual bool IsStroke
    {
        get
        {
            return isStroke;
        }
        set
        {
            isStroke = value;

            if (value)
            {
                BackGround.gameObject.SetActive(true);
            }
            else
            {
                BackGround.gameObject.SetActive(false);
            }
        }
    }


    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        IsEnter = true;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        IsEnter = false;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {

    }

    

    public virtual void OnPointerUp(PointerEventData eventData)
    {

    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        
    }



    public virtual void OnPointerStay()
    {

    }

    private void Update()
    {
        if (IsActive && IsEnter)
            OnPointerStay();

    }
}
