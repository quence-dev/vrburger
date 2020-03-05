using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public enum IngredientType
{
    Bun,
    Cheese,
    Lettuce,
    Patty,
    Pickles,
    Tomato
}

[RequireComponent(typeof(XRGrabInteractable))]
public class grabItem : MonoBehaviour
{
    private XRGrabInteractable grabInteractable = null;

    public IngredientType ingredient;

    // Start is called before the first frame update
    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        GetComponentInChildren<XRSocketInteractor>().socketActive = false;

        grabInteractable.onSelectEnter.AddListener(ActivateSocket);
        grabInteractable.onSelectExit.AddListener(DropBurger);
    }

    private void ActivateSocket(XRBaseInteractor interactor)
    {
        GetComponentInChildren<XRSocketInteractor>().socketActive = true;
        Debug.Log("Socket activated.");


        OnCatchItem();
    }

    private void OnCatchItem()
    {
        //call increment function from ingredient counter
        IngredientCounter.Instance.SubIngredient(ingredient);
        OrderUI.Instance.UpdateOrderText();

        if (ingredient == IngredientType.Bun && (IngredientCounter.Instance.GetBunSum() == 2))
            GameMgr.Instance.CheckForCompletion();
        
        //ObjectPooler.Instance.IncreasePoolSize(ingredient.ToString());
    }

    private void DropBurger(XRBaseInteractor interactor)
    {
        Debug.LogWarning("Item dropped.");
    }
}
