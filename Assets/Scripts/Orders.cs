using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Order", menuName = "Order")]
public class Orders : ScriptableObject
{
    public string orderName;

    public List<ObjectPooler.Pool> activeIngredients;

}
