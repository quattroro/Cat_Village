using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////////
/// 게임 매니저
/// 1. 게임 시작
/// 2. 유저의 레벨과 스테이지 해금상황에 따라 게임을 제어
/// 3. 유저의 입력 제어
/// 
///////////////////////////////////////////////////////////

public class GameManager : Singleton<GameManager>
{

    public UserInfo userInfo;

    public List<BuildingInfo> BuildingInfos = new List<BuildingInfo>();



    #region Input 후에 필요 시 인풋으로 따로 빼준다.

    private BaseBuilding curSelectedBuilding;

    public BaseBuilding CurSelectedBuilding
    {
        get
        {
            return curSelectedBuilding;
        }
        set
        {
            curSelectedBuilding = value;

        }
    }



    #endregion




    public void Awake()
    {
        
    }




}
