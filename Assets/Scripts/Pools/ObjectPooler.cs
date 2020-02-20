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

    public void SpawnFromPool(string tag)
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

        //poolDictionary[tag].Enqueue(clone);

        //return clone;
    }

    public void ReturnToPool(GameObject clone)
    {
        string objectTag = clone.name.Replace("(Clone)", string.Empty);
        clone.SetActive(false);
        clone.transform.rotation = Quaternion.identity;
        poolDictionary[objectTag].Enqueue(clone);
    }

    private Vector3 randSpawnLocation()
    {
        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(10.0f, 12.0f), Random.Range(-1.0f, 1.0f));
        return position;
    }
}
