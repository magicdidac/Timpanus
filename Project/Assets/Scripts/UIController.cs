using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIController : MonoBehaviour
{

    [HideInInspector] private Animator anim;

    [HideInInspector] private InputMaster controls;
    [HideInInspector] private bool notesInput;

    private void Start()
    {
        anim = GetComponent<Animator>();
        controls = GameController.instance.controls;

        controls.Player.Notes.performed += _ => notesInput = true;
        controls.Player.Notes.canceled += _ => notesInput = false;

    }


    private void Update()
    {
        if (notesInput)
        {
            notesInput = false;

            anim.SetTrigger("Change");

        }
    }

}
