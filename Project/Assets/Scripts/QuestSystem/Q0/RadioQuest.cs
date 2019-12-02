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

}
