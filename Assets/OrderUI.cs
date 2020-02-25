using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    public Orders order;

    public Text nameText;
    public Text orderText;


    private string patty, lettuce, cheese, tomato, pickles;

    private void Start()
    {
        nameText.text = order.name;
        orderText.text = CheckOrderCount();

        /*
        itemText1.text = "Cheese: x" + order.cheese.ToString();
        itemText2.text = order.patty.ToString();
        itemText3.text = order.lettuce.ToString();
        itemText4.text = order.tomato.ToString();
        itemText5.text = order.pickles.ToString();
        */
    }

    //check the count of each ingredient to add all items
    //with a quantity above zero
    private string CheckOrderCount()
    {
        string outputText = "";

        foreach(ObjectPooler.Pool order in order.ingreds)
        {
            if (order.size > 0)
            {
                outputText += order.tag + ": x" + order.size + "\n";
            }
        }

        return outputText;
    }


    // Update is called once per frame
    void Update()
    {
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

}
