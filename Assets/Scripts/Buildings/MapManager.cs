using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////////
/// ������ ��� ������ GridSize�� ũ�⿡ �°� Grid�� �����Ѵ�.
/// ���� ������� ������ ������ �ִ´�.
/// 
///////////////////////////////////////////////////////////

public class MapManager : Singleton<MapManager>
{
    [Header("GridOptions")]
    public float GridSize;
    public Vector3 GridStartPos;
    public int GridColCount;
    public int GridRowCount;
    public float GridWidth;
    public LayerMask GridLayerMask;


    public LineRenderer lineRenderer;





    //���߿� �и��ɰ�
    public class MapTile
    {
        public Vector2 Index;
        public GameObject SettedBuild;
        public float TileSize;
        


    }



    [Header("MapInfo")]
    public List<List<MapTile>> MapInfo;




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
                if (CurBuilding != null)
                    CurBuilding.IsBluePrintMode = true;
            }
            else
            {
                InActiveBuildMode();
                if (CurBuilding != null)
                    CurBuilding.IsBluePrintMode = false;
            }
        }
    }

    
    public void InitSetting()
    {
        //�׸����� ��ĭ�� �ǹ��� �� �� ĭ�̴�.




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



    public void BuildingBuild(BaseBuilding building)
    {
        

    }






    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            BuildMode = !BuildMode;
        }

        //if(BuildMode)
        //{
        //    if(CurBuilding!=null)
        //        BuildingBuild(CurBuilding);
        //}

    }










}
