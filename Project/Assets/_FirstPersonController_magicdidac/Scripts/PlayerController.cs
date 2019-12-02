using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerMovement movement = null;
    [SerializeField] private PlayerRaycast raycasts = null;
    [Space]
    [Header("Other")]
    [SerializeField] private LayerMask interactableLayer = 0;

    /** Controls **/
    private InputMaster controls;
    private bool interactInput;

    private void Start()
    {
        movement.Initialize();
        raycasts.Initialize();

        controls = GameController.instance.controls;

        controls.Player.Interact.performed += _ => interactInput = true;
        controls.Player.Interact.canceled += _ => interactInput = false;

    }

    private void Update()
    {
        movement.Move();

        if (interactInput)
        {
            interactInput = false;
            RaycastHit interactableHit;
            if (raycasts.Check(5, interactableLayer, out interactableHit))
            {
                if (interactableHit.transform.GetComponent<Interactable>())
                {
                    interactableHit.transform.GetComponent<Interactable>().Interact();
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            GameController.instance.Die();
        }
    }

    public void Die()
    {
        Debug.Log("Die");
    }

}
