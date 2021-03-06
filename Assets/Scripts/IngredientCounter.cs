﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCounter : MonoBehaviour
{
    #region Singleton
    public static IngredientCounter Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        ResetCounts();
    }

    #endregion

    //only for computing running totals of caught ingredients
    private int pattySum, lettuceSum, tomatoSum, cheeseSum, picklesSum, bunSum;


    #region Getters
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
    public int GetBunSum()
    {
        return bunSum;
    }
    #endregion

    #region Increments
    public void AddPatty()
    {
        pattySum++;
        Debug.Log("Current number of patties: " + pattySum);
    }
    public void AddLettuce()
    {
        lettuceSum++;
        Debug.Log("Current number of lettuce: " + lettuceSum);
    }
    public void AddTomato()
    {
        tomatoSum++;
        Debug.Log("Current number of tomato: " + tomatoSum);
    }
    public void AddCheese()
    {
        cheeseSum++;
        Debug.Log("Current number of cheese: " + cheeseSum);
    }
    public void AddPickles()
    {
        picklesSum++;
        Debug.Log("Current number of pickles: " + picklesSum);
    }
    public void AddBun()
    {
        bunSum++;
        Debug.Log("Current number of buns: " + bunSum);
    }
    #endregion

    public void ResetCounts()
    {
        Debug.Log("Ingredient totals reset.");
        bunSum = 0;
        pattySum = 0;
        lettuceSum = 0;
        tomatoSum = 0;
        cheeseSum = 0;
        picklesSum = 0;
    }

    public void SubIngredient(IngredientType ingredient)
    {
        Debug.Log("Updating number of " + ingredient.ToString());
        switch (ingredient)
        {
            case IngredientType.Patty:
                AddPatty();
                break;
            case IngredientType.Lettuce:
                AddLettuce();
                break;
            case IngredientType.Cheese:
                AddCheese();
                break;
            case IngredientType.Tomato:
                AddTomato();
                break;
            case IngredientType.Pickles:
                AddPickles();
                break;
            case IngredientType.Bun:
                AddBun();
                break;
            default:
                break;
        }
    }

}
