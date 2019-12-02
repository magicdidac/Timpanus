using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIController : MonoBehaviour
{

    [HideInInspector] private Animator anim;

    [HideInInspector] private InputMaster controls;
    [HideInInspector] private bool notesInput;

    [SerializeField] private GameObject tip = null;
    [SerializeField] private GameObject notes = null;
    [SerializeField] private GameObject deathMenu = null;
    [SerializeField] private GameObject winMenu = null;

    private void Start()
    {
        anim = GetComponent<Animator>();
        controls = GameController.instance.controls;

        controls.Player.Notes.performed += _ => notesInput = true;
        controls.Player.Notes.canceled += _ => notesInput = false;

        tip.SetActive(true);
        notes.SetActive(true);
        deathMenu.SetActive(false);
        winMenu.SetActive(false);

    }


    private void Update()
    {
        if (notesInput)
        {
            notesInput = false;

            anim.SetTrigger("Change");

        }
    }

    public void Die()
    {
        tip.SetActive(false);
        notes.SetActive(false);
        winMenu.SetActive(false);
        deathMenu.SetActive(true);
    }

    public void Win()
    {
        tip.SetActive(false);
        notes.SetActive(false);
        deathMenu.SetActive(false);
        winMenu.SetActive(true);
    }

}
