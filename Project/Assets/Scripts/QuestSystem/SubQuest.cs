using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubQuest
{

    public int id;

    [HideInInspector] public int parentQuestId { get; private set; }

    [HideInInspector] public bool isDone { get; private set; }

    [SerializeField] public string title;
    [SerializeField] private FMOD.Studio.EventInstance achivement; 

    public void Initialize(int parentQuestId)
    {
        this.parentQuestId = parentQuestId;
        this.isDone = false;
    }

    public void Done()
    {
        this.isDone = true;

        float last;

        achivement.getParameterByName("Achievement", out last);

        achivement.setParameterByName("Achievement", Mathf.Clamp(last + .2f, 0, 1));
    }

    public override string ToString()
    {
        return "   SubQuest: " + title;
    }

}
