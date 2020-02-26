using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.Events;

public class GameMgr : MonoBehaviour
{
    private int level;

    public List<Orders> orders;

    /*
     * tomato: 0.60
     * lettuce: 0.50
     * cheese: 0.60
     * patty: 0.75
     * pickles: 0.50
     */


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
        //subscribe to event to check for complete order
    }
    #endregion

    public void StartGame()
    {
        spawner.Instance.StartSpawn();
        level = 0;
    }

    public void CheckForCompletion()
    {
        if (OrderIsComplete() && TwoBuns())
        {
            Debug.Log("Order completed");
            //if order is complete and two buns caught, pass level 
            PassLevel();
        }
        else if (TwoBuns() && !OrderIsComplete())
        {
            Debug.Log("Order failed");
            //two buns are caught and order is not complete, fail level    
            FailLevel();
        }
        Debug.Log("Checking order...");
    }

    //Checks if a second (top) bun has been caught.
    private bool TwoBuns()
    {
        int bunCount = IngredientCounter.Instance.GetBunSum();
        Debug.Log("How many buns? " + bunCount);
        if (bunCount == 2)
            return true;
        else
            return false;
    }

    //Checks whether an order is complete.
    private bool OrderIsComplete()
    {
        return false;
    }

    //Pass state for single level. Advances level
    private void PassLevel()
    {
        spawner.Instance.StopSpawn();
        ClearFallingObjects();
        level++;
    }

    //Fail state for single level. Restarts?
    private void FailLevel() 
    {
        spawner.Instance.StopSpawn();
        ClearFallingObjects();
    }

    public Orders GetCurrentOrder()
    {
        return orders[level];
    }

    private void ClearFallingObjects()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("ingredient");

        foreach (GameObject gameObject in gameObjects) {
            XRSocketInteractor tempSocket = gameObject.GetComponentInChildren<XRSocketInteractor>();

            if (!tempSocket.socketActive)
            {
                ObjectPooler.Instance.ReturnToPool(gameObject);
            }
        }
        
    }


}
