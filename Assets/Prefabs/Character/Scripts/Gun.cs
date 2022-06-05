using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ShootPayload
{
    public GameObject caster;
    public RaycastHit hit;
    public float force;
    public bool isPrimaryFire;
}

public class Gun : MonoBehaviour
{   
    [SerializeField]private float range =  100f;
    [SerializeField]private Camera fpsCam;
    [SerializeField]private float force = 200f;
    [SerializeField]private float fireRate = 15f;
    [SerializeField]private ParticleSystem particles;
    [SerializeField]private Color primaryColor;
    [SerializeField]private Color secondaryColor;
    [SerializeField]private GameObject gunModel;
    private Material material;
    private InputManager inputManager;
    private float nextTimeToFire = 0f;
   

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
        material = gunModel.GetComponent<Renderer>().material;
        material.SetColor("_Emission_Color", primaryColor);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextTimeToFire)
        {
            if(inputManager.GetPrimaryWeapon())
            {   
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot(true);
            }
            else if (inputManager.GetSecondaryWeapon())
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot(false);
            }
        }
    }

    void Shoot(bool isPrimaryFire)
    {   
        Color emissionColor = isPrimaryFire ?  primaryColor : secondaryColor;
        material.SetColor("_Emission_Color", emissionColor);
        particles.startColor = emissionColor;
        particles.Play();
        ShootPayload payload = new ShootPayload();
        payload.caster = fpsCam.transform.parent.gameObject;
        payload.force = force;
        payload.isPrimaryFire = isPrimaryFire;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out payload.hit, range))
        {
            IShootable target = payload.hit.transform.GetComponent<IShootable>();
            if (target != null)
            {
                target.Impact(payload);
            }
        }
    }

}