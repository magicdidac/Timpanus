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

    public void Initialize(int parentQuestId)
    {
        this.parentQuestId = parentQuestId;
        this.isDone = false;
    }

    public void Done()
    {
        this.isDone = true;
    }

    public override string ToString()
    {
        return "   SubQuest: " + title;
    }

}
