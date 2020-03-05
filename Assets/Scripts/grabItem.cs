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
    Tomato,
}

[RequireComponent(typeof(XRGrabInteractable))]
public class grabItem : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    private XRGrabInteractable grabInteractable = null;

    public IngredientType ingredient;

    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        socketInteractor.socketActive = false;

        grabInteractable.onSelectEnter.AddListener(ActivateSocket);
    }

    private void ActivateSocket(XRBaseInteractor interactor)
    {
        socketInteractor.socketActive = true;

        //call increment function from ingredient counter
        IngredientCounter.Instance.SubIngredient(ingredient);
        OrderUI.Instance.UpdateOrderText();
        if (ingredient == IngredientType.Bun && (IngredientCounter.Instance.GetBunSum() == 2))
            GameMgr.Instance.CheckForCompletion();
    }
}
