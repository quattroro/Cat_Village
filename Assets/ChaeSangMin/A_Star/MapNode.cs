using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�׽�Ʈ�� �ʵ� ���� ��ĭ�� ������ 

public class MapNode : MonoBehaviour
{
    public bool walkable; //�� ������ ĳ���Ͱ� ���� �� �ִ����� ����
    public Vector3 worldPos; //�� �� ĭ�� ��ġ

    public MapNode(bool _walkable , Vector3 _worldPos) //������
    {
        walkable = _walkable;
        worldPos = _worldPos;
    }
}
