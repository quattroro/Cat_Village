using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////////
/// 월드의 모든 공간을 GridSize의 크기에 맞게 Grid를 생성한다.
/// 또한 월드맵의 정보를 가지고 있는다.
/// 
///////////////////////////////////////////////////////////

public class MapManager : Singleton<MapManager>
{
    public enum TILETYPE { WATER, GROUND, TILEMAX}


    [System.Serializable]
    //나중에 분리될것
    public class MapTile
    {
        public int StageNum;
        public Vector2Int Index;
        public BaseBuilding SettedBuild;
        public float TileSize;
        public TILETYPE TileType;
    }


    [Header("GridOptions")]
    public float GridSize;
    public Vector3 GridStartPos;
    public int GridColCount;
    public int GridRowCount;
    public float GridWidth;
    public LayerMask GridLayerMask;


    public LineRenderer lineRenderer;


    [Header("MapOptions")]
    public Vector3Int MapSize;
    public LayerMask GroundLayer;


    [Header("MapInfo")]
    public MapTile[] MapInfos;


    [Header("BuildBuilding")]
    public BaseBuilding CurBuilding;



    //[SerializeField]
    private bool buildMode;
    public bool BuildMode
    {
        get
        {
            return buildMode;
        }

        set
        {
            buildMode = value;

            if(value)
            {
                ActiveBuildMode();

                //if (CurBuilding != null)
                //    CurBuilding.IsBluePrintMode = true;
            }
            else
            {
                InActiveBuildMode();

                //if (CurBuilding != null)
                //    CurBuilding.IsBluePrintMode = false;
            }
        }
    }

    private void Start()
    {
        InitSetting();
    }

    public void InitSetting()
    {
        Vector3 start = new Vector3(0.5f, 0, 0.5f);
        Vector3 cur = Vector3.zero;
        MapInfos = new MapTile[MapSize.x * MapSize.z];

        //그리드의 한칸이 건물이 들어갈 한 칸이다.
        //처음에 맵정보를 받아온다.
        for (int x=0;x<MapSize.x;x++)
        {
            for(int z=0;z<MapSize.z;z++)
            {
                MapInfos[z + x * MapSize.x] = new MapTile();
                MapInfos[z + x * MapSize.x].Index = new Vector2Int(x, z);

                cur.x = start.x + x;
                cur.z = start.z + z;
                Ray ray = new Ray(cur + Vector3.up, Vector3.down);

                RaycastHit hit;
                Physics.Raycast(ray, out hit, 3, GroundLayer);
                if(hit.collider!=null)
                {
                    //Debug.Log("뭐가 걸리긴 했어");
                    MapInfos[z + x * MapSize.x].TileType = TILETYPE.GROUND;
                    

                }
            }
        }




    }

    void makeGrid(LineRenderer lr, Vector3 startpos, int rowCount, int colCount)
    {
        lr.startWidth = GridWidth;
        lr.endWidth = GridWidth;   

        List<Vector3> gridPos = new List<Vector3>();

        float ec = startpos.z + colCount * GridSize;

        gridPos.Add(new Vector3(startpos.x, startpos.y, startpos.z));
        gridPos.Add(new Vector3(startpos.x, startpos.y, ec));

        int toggle = -1;
        Vector3 currentPos = new Vector3(startpos.x, startpos.y, ec);
        for (int i = 0; i < rowCount; i++)
        {
            Vector3 nextPos = currentPos;

            nextPos.x += GridSize;
            gridPos.Add(nextPos);

            nextPos.z += (colCount * toggle * GridSize);
            gridPos.Add(nextPos);

            currentPos = nextPos;
            toggle *= -1;
        }

        currentPos.x = startpos.x;
        gridPos.Add(currentPos);

        int colToggle = toggle = 1;
        if (currentPos.z == ec) colToggle = -1;

        for (int i = 0; i < colCount; i++)
        {
            Vector3 nextPos = currentPos;

            nextPos.z += (colToggle * GridSize);
            gridPos.Add(nextPos);

            nextPos.x += (rowCount * toggle * GridSize);
            gridPos.Add(nextPos);

            currentPos = nextPos;
            toggle *= -1;
        }

        lr.positionCount = gridPos.Count;
        lr.SetPositions(gridPos.ToArray());
    }


    public void ActiveBuildMode()
    {
        if(lineRenderer.gameObject.activeSelf==false)
            lineRenderer.gameObject.SetActive(true);

        makeGrid(lineRenderer, GridStartPos, GridRowCount, GridColCount);
    }

    public void InActiveBuildMode()
    {
        lineRenderer.gameObject.SetActive(false);
    }

    public GameObject BuildingSelectPanel;
    private bool isshowBuildingSelectMenu;

    public bool IsShowBuildingSelectMenu
    {
        get
        {
            return isshowBuildingSelectMenu;
        }
        set
        {
            isshowBuildingSelectMenu = value;
            BuildingSelectPanel.SetActive(value);
        }
    }

    public void ShowBuildingSelectMenu()
    {
        IsShowBuildingSelectMenu = !IsShowBuildingSelectMenu;
    }

    
    //UI에서 건설할 빌딩을 선택하면 해당 함수가 실행된다.
    public void BuildingBuild(BaseBuilding building)
    {
        if (!BuildMode)
            BuildMode = true;

        building.IsBluePrintMode = true;
        CurBuilding = building;

    }

    //해당 위치에서 건물의 크기만큼 땅이 비어있는 땅이 있는지 확인하고 비어있으면 돈을 줄여주고 해당 위치에 건물을 생성해준다.
    public void SetBuilding(BaseBuilding building)
    {
        Vector3Int index = building.GetSnapPointIndex;

        bool flag = false;
        //Debug.Log("건물 설치 들어옴");
        if (index.x >= 0 && index.x < MapSize.x && index.y >= 0 && index.y < MapSize.z)
        {
            if (building.IsSnaped)
            {
                //Debug.Log("건물 설치 들어옴2");
                for (int x = 0; x < building.buildingInfo.BuildingSize.x; x++)
                {
                    for (int y = 0; y < building.buildingInfo.BuildingSize.y; y++)
                    {
                        Vector3Int curindex = new Vector3Int(index.x + x, 0, index.z + y);
                        //Debug.Log($"{curindex.x},{curindex.y},{curindex.z}검사");

                        if (MapInfos[curindex.z + curindex.x * MapSize.x].TileType == TILETYPE.GROUND
                            && MapInfos[curindex.z + curindex.x * MapSize.x].SettedBuild == null)
                        {
                            //Debug.Log($"{curindex.x},{curindex.y},{curindex.z}통과");
                            flag = true;
                            
                            //Debug.Log("건물설치 성공");
                        }
                        else
                        {
                            //Debug.Log("건물 설치 실패");
                            return;
                        }
                    }

                }

                if (flag)
                {
                    //Debug.Log("건물설치 성공2");
                    for (int x = 0; x < building.buildingInfo.BuildingSize.x; x++)
                    {
                        for (int y = 0; y < building.buildingInfo.BuildingSize.y; y++)
                        {
                            Vector3Int curindex = new Vector3Int(index.x + x, 0, index.z + y);

                            MapInfos[curindex.z + curindex.x * MapSize.x].SettedBuild = CurBuilding;
                        }

                    }
                    building.IsBluePrintMode = false;
                    BuildMode = false;
                    CurBuilding = null;
                }

            }
        }

    }




    public void BuildCancel()
    {
        if(CurBuilding!=null)
        {
            CurBuilding.IsBluePrintMode = false;
            ResourcesManager.instance.DestroyObj<GameObject>(CurBuilding.buildingInfo.PrefabName, CurBuilding.gameObject);
            BuildMode = false;
            CurBuilding = null;
        }
        
    }

    




    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            BuildMode = !BuildMode;
        }
        if(BuildMode&& CurBuilding!=null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                SetBuilding(CurBuilding);
            }
        }

    }










}
