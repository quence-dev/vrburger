using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "ingredient")
            ObjectPooler.Instance.ReturnToPool(collider.gameObject);
    }
}
