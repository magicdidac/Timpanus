using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement
{
    /** Self Components **/
    [Header("Self Components")]
    [SerializeField] private CharacterController characterController = null;
    [SerializeField] private Transform transform = null;

    /** Parameters **/
    [Header("Parameters")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float runSpeed = 15;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float gravity = -9.81f;

    /** Private **/
    private float verticalSpeed = 0;
    private bool isGrounded = false;


    /** Controls **/
    private InputMaster controls;
    private bool jumpInput;
    private bool runInput;
    private Vector2 moveInput;


    public void Initialize()
    {
        controls = GameController.instance.controls;

        controls.Player.Jump.started += _ => jumpInput = true;
        controls.Player.Jump.canceled += _ => jumpInput = false;

        controls.Player.Run.performed += _ => runInput = true;
        controls.Player.Run.canceled += _ => runInput = false;

        controls.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Movement.canceled += _ => moveInput = Vector2.zero;
        
    }


    public void Move()
    {
        Vector3 movement = Vector3.zero;

        float moveX = moveInput.x;
        float moveY = moveInput.y;

        if (moveY > 0)
            movement = transform.forward;
        else if (moveY < 0)
            movement = -transform.forward;

        if (moveX > 0)
            movement += transform.right;
        else if (moveX < 0)
            movement -= transform.right;

        movement.Normalize();

        movement *= Time.deltaTime * (runInput ? runSpeed : speed);

        /** Gracity **/

        verticalSpeed += gravity * Time.deltaTime;
        movement.y = verticalSpeed * Time.deltaTime;

        CollisionFlags collisionFlags = characterController.Move(movement);

        if ((collisionFlags & CollisionFlags.Below) != 0)
        {
            isGrounded = true;
            verticalSpeed = 0;
        }
        else
            isGrounded = false;

        if ((collisionFlags & CollisionFlags.Above) != 0 && verticalSpeed > 0)
            verticalSpeed = 0;

        /** Jump **/

        if (isGrounded && jumpInput)
        {
            jumpInput = false;

            verticalSpeed = jumpForce;
        }

    }

    /** TeleportTo **/

    public void TeleportTo(Vector3 position)
    {
        TeleportTo(position, transform.forward);
    }

    public void TeleportTo(Vector3 position, Vector3 forward)
    {
        characterController.enabled = false;
        transform.position = position;
        characterController.enabled = true;

        transform.forward = forward;
    }

    public void TeleportTo(Transform transform)
    {
        TeleportTo(transform.position, transform.forward);
    }

}
