using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private int level,
    patty = 1,
    lettuce = 1,
    cheese = 1,
    tomato = 1,
    pickles = 1;

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
    }
    #endregion

    public void StartGame()
    {
        spawner.Instance.StartSpawn();
        levelTest();
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (OrderComplete() && twoBuns())
        {
            //if order is complete and two buns caught, pass level 
            spawner.Instance.StopSpawn();
        }
        if (twoBuns() && !OrderComplete())
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
    private bool OrderComplete()
    {
        int cheese, tomato, lettuce, patty, pickles;
        cheese = IngredientCounter.Instance.GetCheese();
        tomato = IngredientCounter.Instance.GetTomato();
        lettuce = IngredientCounter.Instance.GetLettuce();
        patty = IngredientCounter.Instance.GetPatty();
        pickles = IngredientCounter.Instance.GetPickles();

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
        level++;
    }

    //Fail state for single level. Restarts?
    private void FailLevel() 
    {
        
    }

    private void levelTest()
    {
        IngredientCounter.Instance.SetPatty(patty);
        IngredientCounter.Instance.SetLettuce(lettuce);
        IngredientCounter.Instance.SetCheese(cheese);
        IngredientCounter.Instance.SetTomato(tomato);
        IngredientCounter.Instance.SetPickles(pickles);
    }


}
