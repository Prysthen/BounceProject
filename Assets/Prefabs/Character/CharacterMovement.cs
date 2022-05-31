using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 2.0f;
    [SerializeField]private float jumpHeight = 1.0f;
    [SerializeField]private float gravityValue = -9.81f;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
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
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        Vector2 inputValues = inputManager.GetPlayerMovement();
        Vector3 movement = new Vector3(inputValues.x, 0f, inputValues.y);
        movement = cameraTransform.forward * movement.z + cameraTransform.right * movement.x;
        controller.Move(movement * Time.deltaTime * playerSpeed);

    }
}
