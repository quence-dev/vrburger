using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    public Orders order;

    public Text nameText;
    public Text orderText;


    //private string patty, lettuce, cheese, tomato, pickles;

    private void Start()
    {
        nameText.text = order.name;
        orderText.text = InitializeOrder();
    }

    // Update is called once per frame
    void Update()
    {
        orderText.text = UpdateOrder();

        /*
        patty = IngredientCounter.Instance.GetPatty().ToString();
        lettuce = IngredientCounter.Instance.GetLettuce().ToString();
        cheese = IngredientCounter.Instance.GetCheese().ToString();
        tomato = IngredientCounter.Instance.GetTomato().ToString();
        pickles = IngredientCounter.Instance.GetPickles().ToString();
        */

        /*orderText.text = string.Format("Patty: x{0}\n" +
            "Lettuce: x{1}\n" +
            "Cheese: x{2}\n" +
            "Tomato: x{3}\n" +
            "Pickles: x{4}", patty, lettuce, cheese, tomato, pickles);
        */
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
