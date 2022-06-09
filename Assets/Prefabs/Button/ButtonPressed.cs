using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    [SerializeField]private GameObject gameObject;
    private IActivable activable;

    private void Awake()
    {
        if(gameObject != null)
        {
            activable = gameObject.GetComponent<IActivable>();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(gameObject != null)
        {
            activable.Activate();
        }
        Debug.Log("Funciono");
    }

    private void OnTriggerExit(Collider collider)
    {
        if(gameObject != null)
        {
            activable.Deactivate();
        }
    }
}
