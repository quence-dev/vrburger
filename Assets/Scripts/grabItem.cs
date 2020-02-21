using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class grabItem : MonoBehaviour
{
    private XRSocketInteractor socketInteractor = null;
    private XRGrabInteractable grabInteractable = null;

    // Start is called before the first frame update
    void Awake()
    {
        socketInteractor = GetComponentInChildren<XRSocketInteractor>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        socketInteractor.socketActive = false;


        grabInteractable.onSelectEnter.AddListener(ActivateSocket);
    }

    private void ActivateSocket(XRBaseInteractor interactor)
    {
        socketInteractor.socketActive = true;

        string objectTag = this.name.Replace("(Clone)", string.Empty);
        //call increment function from ingredient counter
        IngredientCounter.Instance.SubIngredient(objectTag);
    }
}
