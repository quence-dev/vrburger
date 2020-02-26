using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    public float spawnTime = 1.0f;

    #region Singleton

    public static spawner Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    #endregion

    //public GameObject[] prefab;
    //public GameObject[] clone;

    public void StartSpawn()
    {
        InvokeRepeating("spawnPrefab", spawnTime, spawnTime);
    }

    public void StopSpawn()
    {
        CancelInvoke("spawnPrefab");
    }

    private void spawnPrefab()
    {
        int i = Random.Range(0, 6);

        switch (i)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("Bun");
                break;
            case 1:
                ObjectPooler.Instance.SpawnFromPool("Cheese");
                break;
            case 2:
                ObjectPooler.Instance.SpawnFromPool("Lettuce");
                break;
            case 3:
                ObjectPooler.Instance.SpawnFromPool("Patty");
                break;
            case 4:
                ObjectPooler.Instance.SpawnFromPool("Tomato");
                break;
            case 5:
                ObjectPooler.Instance.SpawnFromPool("Pickles");
                break;
            default:
                break;
        }
    }


    /*
    //Create clone instantiations of burger ingredients.
    void spawnPrefab()
    {
        for (int i = 0; i < 5; i++)
            clone[i] = Instantiate(prefab[randSpawnItem()], randSpawnLocation(), Quaternion.identity) as GameObject;
    }

    //Randomly choose spawn location within boundary
    private Vector3 randSpawnLocation()
    {
        Vector3 position = new Vector3(Random.Range(-1f, 1f), Random.Range(8.0f, 10.0f), Random.Range(-1f, 1f));
        return position;
    }

    private float getRandTime()
    {
        return Random.Range(-0.5f, 0.5f);
    }
    */
}
