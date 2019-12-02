using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : Interactable
{

    private bool isStoped = false;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        GameController.instance.audioManager.PlayAtPosition("Phone", transform);
    }

    private void Update()
    {
        if (isStoped)
            anim.SetBool("isVisible", true);
    }

    public override void Interact()
    {
        if (transform.childCount > 0)
        {
            isStoped = true;
            Destroy(transform.GetChild(0).gameObject);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            anim.SetBool("isVisible", true);
        }
        else
            anim.SetBool("isVisible", false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            anim.SetBool("isVisible", false);
        }
    }

}
