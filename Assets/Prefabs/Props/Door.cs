using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IActivable
{
    private GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.childCount > 0)
        {
            child = transform.GetChild(0).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate()
    {
        this.transform.position += new Vector3(0f, 2f, 0f);
       
        if(child != null)
        {
            child.transform.position -= new Vector3(0f, 2f, 0f);
        }
    }
    public void Deactivate()
    {
        this.transform.position -= new Vector3(0f, 2f, 0f);
        
        if(child != null)
        {
            child.transform.position += new Vector3(0f, 2f, 0f);
        }
    }
}
