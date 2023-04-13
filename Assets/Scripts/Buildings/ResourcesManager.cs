using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////////
/// ���ӿ��� ���Ǵ� ��� ������Ʈ���� ������ �ı��� ����Ѵ�.
/// ������Ʈ Ǯ���� �ʿ��� ���� ��ϸ� �ϸ� Ǯ���� ����� �� �ֵ��� �Ѵ�.
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
            //Debug.Log($"������� {temp.name}");

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

        if (PoolManager.IsPooling(adressableName))//Ǯ���� �ϰ� �ִ� ��ü�� Ǯ������ ������ ����
        {
            Debug.Log("Ǯ�� ������");
            PoolManager.ReturnObject(adressableName, obj);
        }
        else
        {
            Debug.Log("�׳ɻ���");
            //Addressables.ReleaseInstance(obj);
            Destroy(obj);
        }
    }

    public void RegistPoolManager<T>(string _adressablename)
    {
        PoolManager.CreatePool<T>(_adressablename);
    }



}
