using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogQuest : InteractableQuest
{
    protected override void Start()
    {
        base.Start();
        gc.audioManager.PlayAtPosition("Dog-Barking", transform);
    }

    public override void Interact()
    {
        base.Interact();

        if (!anim.GetBool("isVisible"))
            return;


        if (gc.isQuestDone(myQuests[0].parent))
        {
            Destroy(transform.GetChild(0).gameObject);
            gc.audioManager.PlayAtPosition("Dog-Soft", transform);

        }
    }
}
