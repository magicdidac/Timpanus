using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{

    [SerializeField] private Animator anim = null;

    public override void Interact()
    {
        anim.SetBool("isOpen", !anim.GetBool("isOpen"));
    }
}
