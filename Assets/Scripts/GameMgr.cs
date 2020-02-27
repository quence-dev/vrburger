using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using UnityEngine.Events;

public class GameMgr : MonoBehaviour
{
    private int level;

    public List<Orders> orders;
    private int patty, tomato, lettuce, cheese, pickles;

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
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        level = 1;
    }

    #endregion

    public void StartGame()
    {
        spawner.Instance.StartSpawn();
        SetCurrentOrderRequirements();
    }

    public void CheckForCompletion()
    {
        Debug.Log("Checking for completion...");
        bool orderComplete = OrderIsComplete();

        if (orderComplete)
        {
            Debug.Log("Order completed");
            //if order is complete and two buns caught, pass level 
            PassLevel();
        }
        else
        {
            Debug.Log("Order failed");
            //two buns are caught and order is not complete, fail level    
            FailLevel();
        }
    }

    /*
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
    */

    //Checks whether an order is complete.
    private bool OrderIsComplete()
    {
        if (patty >= IngredientCounter.Instance.GetPattySum() &&
            tomato >= IngredientCounter.Instance.GetTomatoSum() &&
            cheese >= IngredientCounter.Instance.GetCheeseSum() &&
            lettuce >= IngredientCounter.Instance.GetLettuceSum() &&
            pickles >= IngredientCounter.Instance.GetPicklesSum())
        {
            Debug.Log("Correct ingredients identified.");
            return true;
        }
        else
        {
            Debug.Log("Order incomplete.");
            return false;
        }

        /*
        foreach (int ingredient in requiredIngredients.Values)
        {
            if (GetCurrentOrder().activeIngredients.Count == ingredient)
                return true;
        }
        return false;
        */
        
    }

    private void SetCurrentOrderRequirements()
    {
        Orders currentOrder = GetCurrentOrder();

        patty = 0;
        tomato = 0;
        lettuce = 0;
        cheese = 0;
        pickles = 0;

        foreach (ObjectPooler.Pool activeIngredients in currentOrder.activeIngredients)
        {
            switch (activeIngredients.tag)
            {
                case "Patty":
                    patty = activeIngredients.size;
                    break;
                case "Tomato":
                    tomato = activeIngredients.size;
                    break;
                case "Lettuce":
                    lettuce = activeIngredients.size;
                    break;
                case "Cheese":
                    cheese = activeIngredients.size;
                    break;
                case "Pickles":
                    pickles = activeIngredients.size;
                    break;
                default:
                    break;
            }
        }
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
