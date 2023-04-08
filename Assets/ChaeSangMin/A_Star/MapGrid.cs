using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �׽�Ʈ�� �� 

public class MapGrid : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize; //���� ũ��
    public float nodeRadius; //�� ĭ�� ������
    MapNode[,] grid; //ĭ�� ������ 2���� �迭

    float nodeDiameter; //�� ĭ�� ����
    int gridSizeX, gridSizeY; // ���� ���� ����

    void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter); // ��ĭ�� ������ ���߾� x ������ ���
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreatGrid();
    }

    void CreatGrid()
    {
        grid = new MapNode[gridSizeX, gridSizeY]; //�Ҵ�
        Vector3 worldBottomLeft = transform.parent.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2; //�׸��带 �׸� ù ������ġ
                
        for (int x = 0; x < gridSizeX; x++) {
            for (int y = 0; y < gridSizeY; y++)
            {
                // ������ġ�� ù �׸���� �׸����� ���߾��� ������ġ�̱⿡ �������� �߰��� ������
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                // Ư�� ��ġ�� Ư�� ����������ŭ �˻������� unwalkableMask���̾��� ture�� ��ȯ�ϱ⿡
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
                grid[x, y] = new MapNode(walkable, worldPoint);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.parent.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));


        if (grid != null)
        {
            foreach (MapNode n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                Gizmos.DrawCube(n.worldPos, Vector3.one * (nodeDiameter - .1f));
            }
        }
    }



}
