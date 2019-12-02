using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableQuest : Interactable
{
    [SerializeField] public List<ParentQuestAndSubquest> myQuests = new List<ParentQuestAndSubquest>();
    [HideInInspector] protected Animator anim;
    [HideInInspector] protected GameController gc;

    protected virtual void Start()
    {
        gc = GameController.instance;
        anim = GetComponent<Animator>();

    }


    private void Update()
    {
        if (gc.isSubQuestDone(myQuests[myQuests.Count - 1].parent, myQuests[myQuests.Count - 1].self))
            anim.SetBool("isVisible", true);
    }

    public override void Interact()
    {
        if (!anim.GetBool("isVisible"))
            return;


        foreach(ParentQuestAndSubquest p in myQuests)
        {
            if(p.before != -1)
            {
                if (!gc.IsDone(p.parent, p.before))
                    return;
            }

            if(!gc.IsDone(p.parent, p.self))
            {
                gc.SubquestDone(p.parent, p.self);
                return;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            anim.SetBool("isVisible", true);
        }else
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
