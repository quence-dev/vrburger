using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCounter : MonoBehaviour
{
    #region Singleton
    public static IngredientCounter Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        ResetCounts();
    }
    #endregion

    //only for tracking total remaining ingredients to be caught
    private int patty, lettuce, tomato, cheese, bun, pickles;

    //only for computing running totals of caught ingredients
    private int pattySum, lettuceSum, tomatoSum, cheeseSum, picklesSum;


    #region Getters and Setters
    public int GetPatty()
    {
        return patty;
    }
    public int GetLettuce()
    {
        return lettuce;
    }
    public int GetTomato()
    {
        return tomato;
    }
    public int GetCheese()
    {
        return cheese;
    }
    public int GetPickles()
    {
        return pickles;
    }
    public int GetBun()
    {
        return bun;
    }
    public void SetPatty(int i)
    {
        patty = i;
    }
    public void SetLettuce(int i)
    {
        lettuce = i;
    }
    public void SetTomato(int i)
    {
        tomato = i;
    }
    public void SetCheese(int i)
    {
        cheese = i;
    }
    public void SetPickles(int i)
    {
        pickles = i;
    }

    public int GetPattySum()
    {
        return pattySum;
    }
    public int GetLettuceSum()
    {
        return lettuceSum;
    }
    public int GetTomatoSum()
    {
        return tomatoSum;
    }
    public int GetCheeseSum()
    {
        return cheeseSum;
    }
    public int GetPicklesSum()
    {
        return picklesSum;
    }
    #endregion

    #region Increments
    public void SubPatty()
    {
        patty--;
        pattySum++;
    }
    public void SubLettuce()
    {
        lettuce--;
        lettuceSum++;
    }
    public void SubTomato()
    {
        tomato--;
        tomatoSum++;
    }
    public void SubCheese()
    {
        cheese--;
        cheeseSum++;
    }
    public void SubPickles()
    {
        pickles--;
        picklesSum++;
    }
    //bun only needs to go up because catching two ends the level
    public void AddBun()
    {
        bun++;
    }
    #endregion

    private void ResetCounts()
    {
        patty = 0;
        lettuce = 0;
        tomato = 0;
        cheese = 0;
        pickles = 0;
        bun = 0;

        pattySum = 0;
        lettuceSum = 0;
        tomatoSum = 0;
        cheeseSum = 0;
        picklesSum = 0;
    }

    public void SubIngredient(string objectTag)
    {
        switch (objectTag)
        {
            case "Patty":
                SubPatty();
                break;
            case "Lettuce":
                SubLettuce();
                break;
            case "Cheese":
                SubCheese();
                break;
            case "Tomato":
                SubTomato();
                break;
            case "Pickles":
                SubPickles();
                break;
            case "Bun":
                AddBun();
                break;
            default:
                break;
        }
    }

}
