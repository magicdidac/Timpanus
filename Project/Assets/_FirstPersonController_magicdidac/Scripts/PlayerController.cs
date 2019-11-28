using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerMovement movement = null;

    private void Awake()
    {
        movement.Instantiate();
    }

    private void Update()
    {
        movement.Move();
    }

}
