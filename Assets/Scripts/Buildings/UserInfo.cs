using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���� ����
public class UserInfo 
{
    int curLevel;
    int curGold;





    public int CurLevel
    {
        get
        {
            return curLevel;
        }
        set
        {
            curLevel = value;
        }
    }

    public int CurGold
    {
        get
        {
            return curGold;
        }
        set
        {
            curGold = value;
        }
    }
        

    public List<List<MapManager.MapTile>> MapInfo;

}
