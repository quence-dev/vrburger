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
    private int remainingPatty, remainingLettuce, remainingTomato, remainingCheese, remainingBun, remainingPickles;

    //only for computing running totals of caught ingredients
    private int pattySum, lettuceSum, tomatoSum, cheeseSum, picklesSum, bunSum;


    #region Getters and Setters
    public int GetPatty()
    {
        return remainingPatty;
    }
    public int GetLettuce()
    {
        return remainingLettuce;
    }
    public int GetTomato()
    {
        return remainingTomato;
    }
    public int GetCheese()
    {
        return remainingCheese;
    }
    public int GetPickles()
    {
        return remainingPickles;
    }
    public int GetBun()
    {
        return remainingBun;
    }
    public void SetPatty(int i)
    {
        remainingPatty = i;
    }
    public void SetLettuce(int i)
    {
        remainingLettuce = i;
    }
    public void SetTomato(int i)
    {
        remainingTomato = i;
    }
    public void SetCheese(int i)
    {
        remainingCheese = i;
    }
    public void SetPickles(int i)
    {
        remainingPickles = i;
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
    public int GetBunSum()
    {
        return bunSum;
    }
    #endregion

    #region Increments
    public void SubPatty()
    {
        remainingPatty--;
        pattySum++;
    }
    public void SubLettuce()
    {
        remainingLettuce--;
        lettuceSum++;
    }
    public void SubTomato()
    {
        remainingTomato--;
        tomatoSum++;
    }
    public void SubCheese()
    {
        remainingCheese--;
        cheeseSum++;
    }
    public void SubPickles()
    {
        remainingPickles--;
        picklesSum++;
    }
    //bun only ever needs to go to two
    public void AddBun()
    {
        remainingBun--;
        bunSum++;
        Debug.Log("Counting buns..." + bunSum);
    }
    #endregion

    private void ResetCounts()
    {
        remainingPatty = 0;
        remainingLettuce = 0;
        remainingTomato = 0;
        remainingCheese = 0;
        remainingPickles = 0;

        remainingBun = 2;
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
                SubPatty();
                break;
            case IngredientType.Lettuce:
                SubLettuce();
                break;
            case IngredientType.Cheese:
                SubCheese();
                break;
            case IngredientType.Tomato:
                SubTomato();
                break;
            case IngredientType.Pickles:
                SubPickles();
                break;
            case IngredientType.Bun:
                AddBun();
                break;
            default:
                break;
        }
    }

}
