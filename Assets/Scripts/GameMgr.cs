using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.XR.Interaction.Toolkit;

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
        if (OrderIsComplete() && twoBuns())
        {
            //if order is complete and two buns caught, pass level 
            PassLevel();
        }
        if (twoBuns() && !OrderIsComplete())
        {
            //two buns are caught and order is not complete, fail level    
            FailLevel();
        }
    }

    //Checks if a second (top) bun has been caught.
    private bool twoBuns()
    {
        int bunCount = IngredientCounter.Instance.GetBun();
        if (bunCount == 2)
            return true;
        else
            return false;
    }

    //Checks whether an order is complete.
    private bool OrderIsComplete()
    {
        int cheese, tomato, lettuce, patty, pickles;

        cheese = IngredientCounter.Instance.GetCheeseSum();
        tomato = IngredientCounter.Instance.GetTomatoSum();
        lettuce = IngredientCounter.Instance.GetLettuceSum();
        patty = IngredientCounter.Instance.GetPattySum();
        pickles = IngredientCounter.Instance.GetPicklesSum();

        string tempString = "";

        foreach (ObjectPooler.Pool order in orders[level].activeIngredients)
        {
            tempString = "Get" + order.tag + "Sum()";

            if (order.size <= IngredientCounter.Instance.GetLettuceSum())
            {
                //outputText += order.tag + ": x" + GetCounts(order).ToString() + "\n";
            }
        }




        if ((cheese <= 0) &&
            (tomato <= 0) && 
            (lettuce <= 0) && 
            (patty <= 0) &&
            (pickles <= 0))
        {
            return true;
        }
        else
            return false;
    }

    //Pass state for single level. Advances level
    private void PassLevel()
    {
        spawner.Instance.StopSpawn();
        level++;
    }

    //Fail state for single level. Restarts?
    private void FailLevel() 
    {
        spawner.Instance.StopSpawn();
    }

    public Orders GetCurrentOrder()
    {
        return orders[level];
    }


}
