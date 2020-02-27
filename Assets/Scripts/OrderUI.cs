using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    private Orders order;

    public Text nameText;
    public Text orderText;

    #region Singleton

    public static OrderUI Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    #endregion

    //private string patty, lettuce, cheese, tomato, pickles;

    private void Start()
    {
        order = GameMgr.Instance.GetCurrentOrder();
        nameText.text = order.name;
        orderText.text = InitializeOrder();
    }

    public void NextLevelUI()
    {
        Debug.Log("UI reset.");
        order = GameMgr.Instance.GetCurrentOrder();
        nameText.text = order.name;
        orderText.text = InitializeOrder();
    }


    //check the count of each ingredient to add all items with a quantity above zero
    private string InitializeOrder()
    {
        string outputText = "";

        foreach(ObjectPooler.Pool order in order.activeIngredients)
        {
            if (order.size > 0)
            {
                outputText += order.tag + ": x" + order.size + "\n";
            }
        }

        return outputText;
    }

    //updates order as items are caught
    public void UpdateOrderText()
    {
        string outputText = "";

        foreach (ObjectPooler.Pool order in order.activeIngredients)
        {
            if (order.size > 0)
            {
                outputText += order.tag + ": x" + GetCounts(order).ToString() + "\n";
            }
        }

        orderText.text = outputText;
    }


    //returns remaining number of ingredient to be caught
    private int GetCounts(ObjectPooler.Pool order)
    {
        int remaining;

        switch (order.tag)
        {
            case "Patty":
                remaining = order.size - IngredientCounter.Instance.GetPattySum();
                if (remaining > 0)
                    return remaining;
                else
                {
                    //Debug.Log("Actual value: " + IngredientCounter.Instance.GetPattySum());
                    return 0;
                }
            case "Lettuce":
                remaining = order.size - IngredientCounter.Instance.GetLettuceSum();
                if (remaining > 0)
                    return remaining;
                else
                {
                    //Debug.Log("Actual value: " + IngredientCounter.Instance.GetLettuceSum());
                    return 0;
                }
            case "Cheese":
                remaining = order.size - IngredientCounter.Instance.GetCheeseSum();
                if (remaining > 0)
                    return remaining;
                else
                {
                    //Debug.Log("Actual value: " + IngredientCounter.Instance.GetCheeseSum());
                    return 0;
                }
            case "Tomato":
                remaining = order.size - IngredientCounter.Instance.GetTomatoSum();
                if (remaining > 0)
                    return remaining;
                else
                {
                    //Debug.Log("Actual value: " + IngredientCounter.Instance.GetTomatoSum());
                    return 0;
                }
            case "Pickles":
                remaining = order.size - IngredientCounter.Instance.GetPicklesSum();
                if (remaining > 0)
                    return remaining;
                else
                {
                    //Debug.Log("Actual value: " + IngredientCounter.Instance.GetPicklesSum());
                    return 0;
                }
            default:
                return 0;
        }
    }

}
