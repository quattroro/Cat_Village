using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 테스트용 맵 

public class MapGrid : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize; //맵의 크기
    public float nodeRadius; //한 칸의 반지름
    MapNode[,] grid; //칸을 저장할 2차원 배열

    float nodeDiameter; //한 칸의 지름
    int gridSizeX, gridSizeY; // 맵의 가로 세로

    void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter); // 한칸의 지름에 맞추어 x 사이즈 계산
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreatGrid();
    }

    void CreatGrid()
    {
        grid = new MapNode[gridSizeX, gridSizeY]; //할당
        Vector3 worldBottomLeft = transform.parent.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2; //그리드를 그릴 첫 시작위치
                
        for (int x = 0; x < gridSizeX; x++) {
            for (int y = 0; y < gridSizeY; y++)
            {
                // 시작위치의 첫 그리드는 그리드의 정중앙이 시작위치이기에 반지름을 추가로 더해줌
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                // 특정 위치에 특정 반지름값만큼 검사했을때 unwalkableMask레이어라면 ture를 반환하기에
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
