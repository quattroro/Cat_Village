using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////////
/// ���� �Ŵ���
/// 1. ���� ����
/// 2. ������ ������ �������� �رݻ�Ȳ�� ���� ������ ����
/// 3. ������ �Է� ����
/// 
///////////////////////////////////////////////////////////

public class GameManager : Singleton<GameManager>
{

    public UserInfo userInfo;

    public List<BuildingInfo> BuildingInfos = new List<BuildingInfo>();


    public void Awake()
    {
        
    }




}
