using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    private Orders order;

    public Text nameText;
    public Text orderText;

    //private string patty, lettuce, cheese, tomato, pickles;

    private void Start()
    {
        order = GameMgr.Instance.GetCurrentOrder();
        nameText.text = order.name;
        orderText.text = InitializeOrder();
    }

    private void Update()
    {
        orderText.text = UpdateOrder();
    }

    //check the count of each ingredient to add all items
    //with a quantity above zero
    private string InitializeOrder()
    {
        string outputText = "";

        foreach(ObjectPooler.Pool order in order.activeIngredients)
        {
            if (order.size > 0)
            {
                outputText += order.tag + ": x" + order.size + "\n";
                SetCounts(order);
            }
        }

        return outputText;
    }

    //updates order as items are caught
    private string UpdateOrder()
    {
        string outputText = "";

        foreach (ObjectPooler.Pool order in order.activeIngredients)
        {
            if (order.size > 0)
            {
                outputText += order.tag + ": x" + GetCounts(order).ToString() + "\n";
            }
        }

        return outputText;
    }

    private void SetCounts(ObjectPooler.Pool order)
    {
        switch (order.tag)
        {
            case "Patty":
                IngredientCounter.Instance.SetPatty(order.size);
                break;
            case "Lettuce":
                IngredientCounter.Instance.SetLettuce(order.size);
                break;
            case "Cheese":
                IngredientCounter.Instance.SetCheese(order.size);
                break;
            case "Tomato":
                IngredientCounter.Instance.SetTomato(order.size);
                break;
            case "Pickles":
                IngredientCounter.Instance.SetPickles(order.size);
                break;
            default:
                break;
        }
    }

    private int GetCounts(ObjectPooler.Pool order)
    {
        switch (order.tag)
        {
            case "Patty":
                return IngredientCounter.Instance.GetPatty();
            case "Lettuce":
                return IngredientCounter.Instance.GetLettuce();
            case "Cheese":
                return IngredientCounter.Instance.GetCheese();
            case "Tomato":
                return IngredientCounter.Instance.GetTomato();
            case "Pickles":
                return IngredientCounter.Instance.GetPickles();
            default:
                return 0;
        }
    }

}
