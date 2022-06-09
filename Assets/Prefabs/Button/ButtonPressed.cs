using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour, IShootable
{
    [SerializeField]private GameObject go;
    private IActivable activable;

    private void Awake()
    {
        if(go != null)
        {
            activable = go.GetComponent<IActivable>();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(go != null)
        {
            activable.Activate();
        }
        Debug.Log("Funciono");
    }

    private void OnTriggerExit(Collider collider)
    {
        if(go != null)
        {
            activable.Deactivate();
        }
    }

     public void Impact(ShootPayload payload)
    {
        float force = payload.force * -0.25f;
        CharacterMovement cm = payload.caster.GetComponent<CharacterMovement>();
        cm.AddImpact((payload.caster.transform.position - payload.hit.point).normalized, (payload.isPrimaryFire ? force : -force));
        Debug.Log(payload.hit.point - payload.caster.transform.position);
    }
}
