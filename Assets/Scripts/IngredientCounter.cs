using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientCounter : MonoBehaviour
{
    private int patty, lettuce, tomato, cheese;

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
    public void AddPatty()
    {
        patty++;
    }
    public void AddLettuce()
    {
        lettuce++;
    }
    public void AddTomato()
    {
        tomato++;
    }
    public void AddCheese()
    {
        cheese++;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetCountToZero();
    }

    private void SetCountToZero()
    {
        patty = 0;
        lettuce = 0;
        tomato = 0;
        cheese = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
