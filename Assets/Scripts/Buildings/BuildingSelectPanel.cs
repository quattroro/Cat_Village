using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


///////////////////////////////////////////////////////////
/// 빌딩을 건설할때 건설할 빌딩을 선택하게 해줄 패널
/// 존재하는 모든 빌딩에 대하여 각각 해당하는 빌딩의 정보를 가지고 있는다.
/// 아직 언락되지 않은 빌딩의 경우에는 비활성화 되어 있는다.
///////////////////////////////////////////////////////////

public class BuildingSelectPanel : UIPointerAdapter
{
    public List<List<BuildingSelectNode>> Nodes;

    public Vector2 Padding;

    public int MaxNode;

    public Scrollbar ScrollBar;

    public string BuildNodeName;

    public Transform StartPos;

    private Vector2 NodeSize;

    private int curSeletedType;
    private int LastSeletedType;
    private RectTransform MyRectTransform;

    public GameObject ScrollPanel;

    public int CurSeletedType
    {
        get
        {
            return curSeletedType;
        }
        set
        {
            LastSeletedType = curSeletedType;
            curSeletedType = value;
            ShowSelectNodes(value);
        }
    }

    private void Start()
    {
        InitSetting();
    }

    //private void OnEnable()
    //{
    //    if (MyRectTransform == null)
    //        InitSetting();
    //}

    public void InitSetting()
    {
        MyRectTransform = GetComponent<RectTransform>();

        Nodes = new List<List<BuildingSelectNode>>((int)BUILDINGTYPE.BUILDINGTYPEMAX);

        for (int i = 0; i < (int)BUILDINGTYPE.BUILDINGTYPEMAX; i++)
        {
            Nodes.Add(new List<BuildingSelectNode>());
        }

        for (int i=0;i< GameManager.Instance.BuildingInfos.Count;i++)
        {
            AddBuildingSelectNode(GameManager.Instance.BuildingInfos[i]);
        }

        CurSeletedType = 0;

    }


    //처음 초기화 단계에 빌딩 메뉴를 생성하는데 사용한다.
    private void AddBuildingSelectNode(BuildingInfo buildingInfo)
    {
        //Debug.Log($"list count : {Nodes.Count}, now num : {(int)buildingInfo.BuildingType}");

        //if (Nodes[(int)buildingInfo.BuildingType] == null)
        //    Nodes[(int)buildingInfo.BuildingType] = new List<BuildingSelectNode>();

        GameObject obj = ResourcesManager.Instance.InstantiateObj<GameObject>("Prefabs/BuildingSelectNode", false);
        BuildingSelectNode node = obj.GetComponent<BuildingSelectNode>();
        node.BuildingInfo = buildingInfo;

        obj.transform.parent = StartPos.transform;
        obj.transform.position = new Vector3(StartPos.position.x + (Padding.x * Nodes[(int)buildingInfo.BuildingType].Count), StartPos.position.y + (Padding.y * Nodes[(int)buildingInfo.BuildingType].Count), 0);


        Nodes[(int)buildingInfo.BuildingType].Add(obj.GetComponent<BuildingSelectNode>());

        obj.SetActive(false);
    }

    private void SetPanelSize(int buildingType)
    {
        int nodenum = Nodes[buildingType].Count;
        NodeSize = Nodes[buildingType][0].GetComponent<RectTransform>().sizeDelta;

        Vector2 temp = ScrollPanel.GetComponent<RectTransform>().sizeDelta;
        ScrollPanel.GetComponent<RectTransform>().sizeDelta = new Vector2((Padding.x * (nodenum + 1)) + (NodeSize.x * nodenum), temp.y);
    }





    private void ShowSelectNodes(int buildingType)
    {
        for(int i=0;i<Nodes[LastSeletedType].Count;i++)
        {
            Nodes[LastSeletedType][i].gameObject.SetActive(false);
        }
        for(int i=0;i<Nodes[buildingType].Count;i++)
        {
            Nodes[buildingType][i].gameObject.SetActive(true);
        }
    }



}
