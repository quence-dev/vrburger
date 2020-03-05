using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public Queue<GameObject> objectPool;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            //return null;
        }

        GameObject clone = poolDictionary[tag].Dequeue();

        clone.SetActive(true);
        clone.transform.position = randSpawnLocation();
        clone.transform.rotation = Quaternion.identity;

        poolDictionary[tag].Enqueue(clone);

        return clone;
    }

    public void ReturnToPool(GameObject clone)
    {
        string objectTag = clone.name.Replace("(Clone)", string.Empty);
        clone.transform.rotation = Quaternion.identity;
        clone.SetActive(false);
        poolDictionary[objectTag].Enqueue(clone);
    }

    public void IncreasePoolSize(string tag)
    {
        Pool pool = FindObjectPool(tag);


        GameObject obj = Instantiate(pool.prefab);
        obj.SetActive(false);
        poolDictionary[tag].Enqueue(obj);
        Debug.Log(pool.tag + " Pool size has been increased to: " + poolDictionary[tag].Count);
    }

    private Pool FindObjectPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            //return null;
        }

        foreach (Pool pool in pools)
        {
            if (pool.tag.Equals(tag))
                return pool;
        }
        return null;
    }

    private Vector3 randSpawnLocation()
    {
        Vector3 position = new Vector3(Random.Range(-0.8f, 0.8f), 20f, Random.Range(-0.8f, 0.8f));
        return position;
    }
}
