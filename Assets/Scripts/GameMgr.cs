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
        level = 0;
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

    //Checks whether an order is complete.
    private bool OrderIsComplete()
    {
        if (patty <= IngredientCounter.Instance.GetPattySum() &&
            tomato <= IngredientCounter.Instance.GetTomatoSum() &&
            cheese <= IngredientCounter.Instance.GetCheeseSum() &&
            lettuce <= IngredientCounter.Instance.GetLettuceSum() &&
            pickles <= IngredientCounter.Instance.GetPicklesSum())
        {
            Debug.Log("Correct ingredients.");
            return true;
        }
        else
        {
            Debug.Log("Incorrect ingredients.");
            return false;
        }
    }

    private void SetCurrentOrderRequirements()
    {
        Debug.Log("Setting order requirements...");
        Orders currentOrder = orders[level];

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
                    Debug.Log("Number of " + activeIngredients.tag + " required: " + activeIngredients.size);
                    patty = activeIngredients.size;
                    break;
                case "Tomato":
                    Debug.Log("Number of " + activeIngredients.tag + " required: " + activeIngredients.size);
                    tomato = activeIngredients.size;
                    break;
                case "Lettuce":
                    Debug.Log("Number of " + activeIngredients.tag + " required: " + activeIngredients.size);
                    lettuce = activeIngredients.size;
                    break;
                case "Cheese":
                    Debug.Log("Number of " + activeIngredients.tag + " required: " + activeIngredients.size);
                    cheese = activeIngredients.size;
                    break;
                case "Pickles":
                    Debug.Log("Number of " + activeIngredients.tag + " required: " + activeIngredients.size);
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
        IngredientCounter.Instance.ResetCounts();

        level++;
        Debug.Log("(Pass) Loading Next Level....");

        SetCurrentOrderRequirements();
        OrderUI.Instance.NextLevelUI();
        spawner.Instance.StartSpawn();
    }


    //Fail state for single level. Restarts level
    private void FailLevel()
    {
        Debug.Log("(Fail) Restarting level... ");
        spawner.Instance.StopSpawn();
        ClearFallingObjects();
        IngredientCounter.Instance.ResetCounts();

        OrderUI.Instance.NextLevelUI();
        spawner.Instance.StartSpawn();
    }

    public Orders GetCurrentOrder()
    {
        Debug.Log("Fetching current order: " + orders[level].name);
        return orders[level];
    }

    private void ClearFallingObjects()
    {
        Debug.Log("Clearing falling objects from scene.");
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("ingredient");

        foreach (GameObject gameObject in gameObjects)
        {
            XRSocketInteractor tempSocket = gameObject.GetComponentInChildren<XRSocketInteractor>();

            if (!tempSocket.socketActive)
            {
                ObjectPooler.Instance.ReturnToPool(gameObject);
            }
        }
    }


}
