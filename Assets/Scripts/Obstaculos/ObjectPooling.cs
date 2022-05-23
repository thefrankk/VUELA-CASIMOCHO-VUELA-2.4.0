//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //Singleton method
    private static ObjectPooling instance;

    public static Dictionary<int, Queue<GameObject>> pool = new Dictionary<int, Queue<GameObject>>();
    public static Dictionary<int, Queue<GameObject>> parents = new Dictionary<int, Queue<GameObject>>();
    private void Awake()
    {
        //
        if (instance == null)
        {
            instance = this;
        }    
        else
        {
            Destroy(this);
        }   
    }
  

    //Precarga de nro de objetos.
    public static void PreLoad(GameObject objectToPool, int amount)
    {
        int id = objectToPool.GetInstanceID();


        GameObject parent = new GameObject();
        parent.name = objectToPool.name + " Pool";
        parents.Add(id, new Queue<GameObject>());

        pool.Add(id, new Queue<GameObject>());


        for(int i = 0; i < amount; i++)
        {
            CreateObject(objectToPool);
        }    
    }    

    static void CreateObject(GameObject objectToPool)
    {
        int id = objectToPool.GetInstanceID();

        GameObject go = Instantiate(objectToPool) as GameObject;
      //  go.transform.SetParent(GetParent(id).transform);
        go.SetActive(false);

        pool[id].Enqueue(go);

    }
    //static GameObject GetParent(int parentID)
    //{

     // GameObject parent;
     // parents.TryGetValue(parentID,out parent);

     //  return parent;
    //}

    public static GameObject GetObject(GameObject objectToPool)
    {
        int id = objectToPool.GetInstanceID();

        if(pool[id].Count == 0)
        {
            CreateObject(objectToPool);
        }

        GameObject go = pool[id].Dequeue();
        go.SetActive(true);

        return go;
    }

    public static void RecicleObject(GameObject objectToPool, GameObject ObjectToRecicle)
    {
        int id = objectToPool.GetInstanceID();

        pool[id].Enqueue(ObjectToRecicle);
        ObjectToRecicle.SetActive(false);
    }

    public void RemoveObject(GameObject objectToRemove)
    {
        int id = objectToRemove.GetInstanceID();
        
    }
}
