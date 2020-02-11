using UnityEngine;

public class AltColorChanger : MonoBehaviour
{
    public Material inactiveMaterial;
    public Material activeMaterial;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Activate(bool value)
    {
        meshRenderer.material = value ? activeMaterial : inactiveMaterial;
    }
}
