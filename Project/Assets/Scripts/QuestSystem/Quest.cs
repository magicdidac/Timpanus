using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{

    [HideInInspector] public int id { get; private set; }
    [HideInInspector] public bool isDone { get; private set; }

    [SerializeField] public string title;
    [SerializeField] public List<SubQuest> subQuests = new List<SubQuest>();



    public void Initialize(int id)
    {
        this.id = id;
        this.isDone = false;

        for(int i = 0; i < subQuests.Count; i++)
        {
            subQuests[i].Initialize(i + 1);
        }

    }

    public void QuestDone()
    {
        this.isDone = true;
    }

    public void SubQuestDone(int id)
    {
        subQuests[id].Done();
    }

    public override string ToString()
    {
        string message = "";

        message = "Quest: " + title;

        foreach(SubQuest s in subQuests)
        {
            message += "\n" + s.ToString();
        }

        return message;
    }

}
