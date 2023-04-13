using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyObjectPool
{
    //�ش� Ÿ���� Ǯ���� ���� �����Ѵ�.
    public class ObjectPoolManager
    {
        public Dictionary<string, ObjectPool> PoolDic = new Dictionary<string, ObjectPool>();

        //public bool IsPooling(string typestring)
        //{
        //    return PoolDic.ContainsKey(typestring);
        //}

        public bool IsPooling(string adressableName)
        {
            return PoolDic.ContainsKey(adressableName);
        }

        ////Ÿ������ ����
        //public void CreatePool<T>(string adressableName,int poolsize=10) 
        //{
        //    //string typename = obj.GetType().Name;
        //    ObjectPool pool = null;

        //    //�̹� �ش� Ÿ���� Ǯ�� �ִ��� Ȯ���ϰ� ������ ����� �ش�.
        //    PoolDic.TryGetValue(typeof(T).Name, out pool);
        //    Debug.Log(typeof(T).Name +"Ǯ ���� ����");

        //    if(pool==null)
        //    {
        //        Debug.Log(typeof(T).Name + "Ǯ ���� �õ�");
        //        pool = new ObjectPool(adressableName, typeof(T), poolsize);
        //        PoolDic.Add(typeof(T).Name, pool);
        //    }

        //}

        //��巹���� �������� ����
        public void CreatePool<T>(string adressableName, int poolsize = 10)
        {
            //string typename = obj.GetType().Name;
            ObjectPool pool = null;

            //�̹� �ش� Ÿ���� Ǯ�� �ִ��� Ȯ���ϰ� ������ ����� �ش�.
            PoolDic.TryGetValue(adressableName, out pool);
            Debug.Log(adressableName + "Ǯ ���� ����");

            if (pool == null)
            {
                Debug.Log(adressableName + "Ǯ ���� �õ�");
                pool = new ObjectPool(adressableName, typeof(T), poolsize);
                PoolDic.Add(adressableName, pool);
            }

        }

        //public T GetObject<T>()
        //{
        //    ObjectPool pool = null;
        //    PoolDic.TryGetValue(typeof(T).Name, out pool);

        //    if(pool!=null)
        //    {
        //        return pool.GetObj().GetComponent<T>();
        //    }

        //    Debug.LogError("�������� �ʴ� Ÿ��");
        //    return default(T);
        //}

        //�������� ����
        public T GetObject<T>(string adressableName) where T : class
        {
            ObjectPool pool = null;
            PoolDic.TryGetValue(adressableName, out pool);

            if (pool != null)
            {
                if (typeof(T) == typeof(GameObject))
                    return pool.GetObj() as T;
                else
                    return pool.GetObj().GetComponent<T>();
            }

            Debug.LogError("�������� �ʴ� Ÿ��");
            return default(T);
        }

        //public void ReturnObject(System.Type _type, GameObject obj)
        //{
        //    ObjectPool pool = null;

        //    bool flag = PoolDic.ContainsKey(_type.Name);
        //    //

        //    if (flag)
        //    {
        //        PoolDic.TryGetValue(_type.Name, out pool);
        //        pool.ReturnObj(obj);
        //    }
        //}


        //�������� ����
        public void ReturnObject(string adressableName, GameObject obj)
        {
            if (obj == null)
                return;

            ObjectPool pool = null;
            bool flag = PoolDic.ContainsKey(adressableName);
            if (flag)
            {
                PoolDic.TryGetValue(adressableName, out pool);
                pool.ReturnObj(obj);
            }
        }

    }


    //Ǯ�� ���ӿ�����Ʈ�� ����
    //��ü�� �⺻������ 10�� ����
    public class ObjectPool/*<T>:ObjectPoolBase*/
    {
        //T _poolObj;
        //string AdressableName;

        string ObjectName;

        System.Type _type;

        public Stack<GameObject> _stack;
        int _poolSize = 0;
        Transform _parent;


        public ObjectPool(string adressableName, System.Type type, int poolsize)
        {
            _stack = new Stack<GameObject>();
            //System.Type _type = System.Type.GetType(_Name);
            _type = type;


            //��巹���� ���� �ý��� ����
            //_adressableName = adressableName;
            //Resources���� ����
            ObjectName = adressableName;

            _poolSize = poolsize;


            CreateObj(_poolSize);

            Debug.Log(_type.Name + "Ǯ ���� �Ϸ�");



        }


        public void CreateObj(int count)
        {
            for (int i = 0; i < count; i++)
            {
                //��巹���� ���� �ý��� ����
                //var temp = Addressables.InstantiateAsync(_adressableName);
                //var result = temp.WaitForCompletion();
                //result.SetActive(false);
                //_stack.Push(result);


                //Resources ���� ����
                var temp = Resources.Load<GameObject>(ObjectName);
                var result = GameObject.Instantiate<GameObject>(temp);

                result.SetActive(false);
                _stack.Push(result);


            }
        }


        public GameObject GetObj()
        {
            GameObject temp = null;

            if (_stack.Count > 0)
                temp = _stack.Pop();

            if (temp == null)
            {
                CreateObj(1);
                temp = _stack.Pop();
            }
            temp.SetActive(true);
            temp.transform.SetParent(null);

            return temp;
        }

        public void ReturnObj(GameObject obj)
        {
            if (obj == null)
                return;

            if (_stack.Contains(obj))
                return;

            obj.SetActive(false);
            _stack.Push(obj);
        }


    }
}