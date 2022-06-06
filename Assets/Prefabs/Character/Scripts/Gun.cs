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
    [SerializeField]private ParticleSystem primaryParticles;
    [SerializeField]private ParticleSystem secondaryParticles;
    [SerializeField]private Color primaryColor;
    [SerializeField]private Color secondaryColor;
    [SerializeField]private GameObject gunModel;
    [SerializeField]private float emissiveForce = 1f;
    private Animator animator;
    private Material material;
    private InputManager inputManager;
    private float nextTimeToFire = 0f;

   

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
        material = gunModel.GetComponent<Renderer>().material;
        material.SetColor("_Emission_Color", primaryColor);
        material.SetFloat("_Emissive_Force", emissiveForce);
        animator = GetComponent<Animator>();
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
            } else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) 
            {
                animator.SetBool("Shooting", true);
            }
        }
    }

    void Shoot(bool isPrimaryFire)
    {   
        ParticleSystem particles = isPrimaryFire ? primaryParticles : secondaryParticles;
        animator.SetBool("Shooting", true);
        Color emissionColor = isPrimaryFire ? primaryColor : secondaryColor;
        material.SetColor("_Emission_Color", emissionColor);
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
