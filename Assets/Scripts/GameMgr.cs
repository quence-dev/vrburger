using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{

    #region Singleton
    public static GameMgr Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public void StartGame()
    {
        spawner.Instance.StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Updates as items are caught
    public void CheckOrder()
    {

    }

    public void CompleteLevel()
    {

    }

    public void FailLevel() 
    {

    }
}
