using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 2.0f;
    [SerializeField]private float jumpHeight = 1.0f;
    [SerializeField]private float gravityValue = -9.81f;
    [SerializeField]private float groundDistance = 0.4f;
    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask groundMask;
    private CharacterController controller;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Vector3 velocity;
    private Transform cameraTransform;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 lookDirection = cameraTransform.forward;
        lookDirection.x = 0;
        lookDirection.z = 0;
        groundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(groundedPlayer && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector2 inputDirection = inputManager.GetPlayerMovement();
        Vector3 direction = cameraTransform.right * inputDirection.x + cameraTransform.forward * inputDirection.y;
        controller.Move(direction * playerSpeed * Time.deltaTime);

        if(inputManager.GetJump() && groundedPlayer)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
