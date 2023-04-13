using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////////
/// 게임에서 사용되는 모든 오브젝트들의 생성과 파괴를 담당한다.
/// 오브젝트 풀링이 필요할 때는 등록만 하면 풀링을 사용할 수 있도록 한다.
///////////////////////////////////////////////////////////

public class ResourcesManager : Singleton<ResourcesManager>
{
    MyObjectPool.ObjectPoolManager PoolManager = new MyObjectPool.ObjectPoolManager();

    Dictionary<string, List<GameObject>> ObjList;

    public T InstantiateObj<T>(string objName,bool isPooling) where T:class
    {
        if(PoolManager.IsPooling(objName))
        {
            return PoolManager.GetObject<T>(objName);
        }
        else
        {
            if (isPooling)
            {
                RegistPoolManager<T>(objName);
                return PoolManager.GetObject<T>(objName);
            }

            
            GameObject temp = Resources.Load<GameObject>(objName);
            GameObject result = GameObject.Instantiate<GameObject>(temp);
            //Debug.Log($"만들어짐 {temp.name}");

            //if (ObjList.ContainsKey(objName))
            //    ObjList[objName].Add(temp);
            //else
            //{
            //    List<GameObject> list = new List<GameObject>();
            //    list.Add(temp);
            //    ObjList.Add(objName, list);
            //}    
                

            if (typeof(T) != typeof(GameObject))
                return result.GetComponentInChildren<T>();
            else
                return result as T;
        }
    }

    public void DestroyObj<T>(string adressableName, GameObject obj)
    {
        if (obj == null)
            return;

        if (PoolManager.IsPooling(adressableName))//풀링을 하고 있는 객체면 풀링에서 꺼내서 삭제
        {
            Debug.Log("풀링 돌려줌");
            PoolManager.ReturnObject(adressableName, obj);
        }
        else
        {
            Debug.Log("그냥삭제");
            //Addressables.ReleaseInstance(obj);
            Destroy(obj);
        }
    }

    public void RegistPoolManager<T>(string _adressablename)
    {
        PoolManager.CreatePool<T>(_adressablename);
    }



}
