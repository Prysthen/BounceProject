using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IShootable
{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Impact(ShootPayload payload)
    {
        float force = payload.force * 30f;
        CharacterMovement cm = payload.caster.GetComponent<CharacterMovement>();
        cm.AddImpact((payload.caster.transform.position - payload.hit.point).normalized, (payload.isPrimaryFire ? force : -force));
        Debug.Log(payload.hit.point - payload.caster.transform.position);
    }
}
