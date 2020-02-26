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
        SetCountToZero();
    }
    #endregion

    private int patty, lettuce, tomato, cheese, bun, pickles;

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
    #endregion

    #region Increments
    public void SubPatty()
    {
        patty--;
    }
    public void SubLettuce()
    {
        lettuce--;
    }
    public void SubTomato()
    {
        tomato--;
    }
    public void SubCheese()
    {
        cheese--;
    }
    public void SubPickles()
    {
        pickles--;
    }
    public void AddBun()
    {
        bun++;
    }
    #endregion

    private void SetCountToZero()
    {
        patty = 0;
        lettuce = 0;
        tomato = 0;
        cheese = 0;
        pickles = 0;
        bun = 0;
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
