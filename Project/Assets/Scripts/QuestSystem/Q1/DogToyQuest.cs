using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogToyQuest : InteractableQuest
{

    public override void Interact()
    {
        base.Interact();

        if (gc.isSubQuestDone(myQuests[0].parent, myQuests[0].self))
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            gc.audioManager.Play("DogToy");
        }
    }

}
