using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public Material greyMaterial = null;
    public Material blueMaterial = null;

    private MeshRenderer meshRenderer = null;
    private XRGrabInteractable grabInteractable = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.onActivate.AddListener(SetBlue);
        grabInteractable.onDeactivate.AddListener(SetGrey);
    }

    private void OnDestroy()
    {
        grabInteractable.onActivate.RemoveListener(SetBlue);
        grabInteractable.onDeactivate.RemoveListener(SetGrey);
    }

    private void SetGrey(XRBaseInteractor interactor)
    {
        meshRenderer.material = greyMaterial;
    }

    private void SetBlue(XRBaseInteractor interactor)
    {
        meshRenderer.material = blueMaterial;
    }
}
