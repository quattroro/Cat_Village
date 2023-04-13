using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


///////////////////////////////////////////////////////////
/// ������ �Ǽ��Ҷ� �Ǽ��� ������ �����ϰ� ���� �г�
/// �����ϴ� ��� ������ ���Ͽ� ���� �ش��ϴ� ������ ������ ������ �ִ´�.
/// ���� ������� ���� ������ ��쿡�� ��Ȱ��ȭ �Ǿ� �ִ´�.
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


    //ó�� �ʱ�ȭ �ܰ迡 ���� �޴��� �����ϴµ� ����Ѵ�.
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
