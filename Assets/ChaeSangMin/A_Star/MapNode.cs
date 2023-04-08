using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//테스트용 필드 맵의 한칸의 데이터 

public class MapNode : MonoBehaviour
{
    public bool walkable; //이 영역을 캐릭터가 걸을 수 있는지에 대해
    public Vector3 worldPos; //이 한 칸의 위치

    public MapNode(bool _walkable , Vector3 _worldPos) //생성자
    {
        walkable = _walkable;
        worldPos = _worldPos;
    }
}
