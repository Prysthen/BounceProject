using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IShootable
{
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Impact(ShootPayload payload)
    {
        rb.AddForce((payload.hit.point - payload.caster.transform.position).normalized * (payload.isPrimaryFire ? payload.force : -payload.force));
        Debug.Log(payload.hit.point - payload.caster.transform.position);
    }
}
