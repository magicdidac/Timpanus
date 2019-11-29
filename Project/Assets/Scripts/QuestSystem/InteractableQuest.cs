using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableQuest : Interactable
{
    [SerializeField] public List<ParentQuestAndSubquest> myQuests = new List<ParentQuestAndSubquest>();
    [HideInInspector] private GameController gc;

    private void Start()
    {
        gc = GameController.instance;
    }


    public override void Interact()
    {

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
}
