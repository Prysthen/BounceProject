using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz que nos permite comunicarnos con el plugin de unity "input system"

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    private PlayerControls playerControls;
   
    public static InputManager Instance
    {
        get 
        {
            return _instance;
        }
    }

    void Awake()
    {
        playerControls = new PlayerControls();

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    
    public Vector2 GetPlayerMovement()
    {
       return playerControls.Playing.Walk.ReadValue<Vector2>();
    }
    public bool GetJump()
    {
        return playerControls.Playing.Jump.triggered;
    }
    public bool GetPrimaryWeapon()
    {
        return playerControls.Playing.PrimaryWeapon.triggered;
    }
    public bool GetSecondaryWeapon()
    {
        return playerControls.Playing.SecondaryWeapon.triggered;
    }
    public bool GetInteract()
    {
        return playerControls.Playing.Interact.triggered;
    }

}
