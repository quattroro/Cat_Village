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
    public List<BuildingSelectNode> Nodes;

    public Vector2 Padding;

    public int MaxNode;

    public Scrollbar ScrollBar;

    public string BuildNodeName;

    public Transform StartPos;

    private void Start()
    {
        InitSetting();
    }

    public void InitSetting()
    {
        for(int i=0;i< GameManager.Instance.BuildingInfos.Count;i++)
        {
            AddBuildingSelectNode(GameManager.Instance.BuildingInfos[i]);
        }
    }


    //처음 초기화 단계에 빌딩 메뉴를 생성하는데 사용한다.
    public void AddBuildingSelectNode(BuildingInfo buildingInfo)
    {
        
        GameObject obj = ResourcesManager.Instance.InstantiateObj<GameObject>("Prefabs/BuildingSelectNode", false);
        BuildingSelectNode node = obj.GetComponent<BuildingSelectNode>();
        node.BuildingInfo = buildingInfo;

        obj.transform.parent = this.transform;
        obj.transform.position = new Vector3(StartPos.position.x + (Padding.x * Nodes.Count), StartPos.position.y + (Padding.y * Nodes.Count), 0);



        Nodes.Add(obj.GetComponent<BuildingSelectNode>());

    }




}
