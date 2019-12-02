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
    [FMODUnity.EventRef]
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

        //achivement.getParameterByName("Achievement", out last);
        Debug.Log(FMODUnity.RuntimeManager.StudioSystem.getParameterByName("Achievement", out last));
        Debug.Log(last);
        Debug.Log(FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Achievement", Mathf.Clamp(last + .2f, 0, 1)));
        //achivement.setParameterByName("Achievement", Mathf.Clamp(last + .2f, 0, 1));
        
        Debug.Log(last);

    }

    public override string ToString()
    {
        return "   SubQuest: " + title;
    }

}
