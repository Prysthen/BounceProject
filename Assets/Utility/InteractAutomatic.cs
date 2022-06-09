using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAutomatic : MonoBehaviour
{
    [SerializeField]private GameObject go;
    private IActivable activable;

    private void Awake()
    {
        activable = go.GetComponent<IActivable>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<CharacterController>() != null)
        {
            activable.Activate();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.GetComponent<CharacterController>() != null)
        {
            activable.Deactivate();
        }
    }
}
 