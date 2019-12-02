using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioQuest : InteractableQuest
{

    protected override void Start()
    {
        base.Start();
        gc.audioManager.PlayAtPosition("Radio-Song", transform);
    }

    public override void Interact()
    {
        base.Interact();

        if(gc.isSubQuestDone(myQuests[0].parent, myQuests[0].self))
        {
            Destroy(transform.GetChild(0).gameObject);
        }

    }

}
