﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public Text orderTicket;
    private string patty, lettuce, cheese, tomato, pickles;


    // Update is called once per frame
    void Update()
    {
        patty = IngredientCounter.Instance.GetPatty().ToString();
        lettuce = IngredientCounter.Instance.GetLettuce().ToString();
        cheese = IngredientCounter.Instance.GetCheese().ToString();
        tomato = IngredientCounter.Instance.GetTomato().ToString();
        pickles = IngredientCounter.Instance.GetPickles().ToString();

        orderTicket.text = string.Format("Patty: x{0}\n" +
            "Lettuce: x{1}\n" +
            "Cheese: x{2}\n" +
            "Tomato: x{3}\n" +
            "Pickles: x{4}", patty, lettuce, cheese, tomato, pickles);              
    }




}
