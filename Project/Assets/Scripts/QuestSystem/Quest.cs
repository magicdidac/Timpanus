using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{

    [SerializeField] public int id;
    [HideInInspector] public bool isDone { get; private set; }

    [SerializeField] public string title;
    [SerializeField] public List<SubQuest> subQuests = new List<SubQuest>();



    public void Initialize(int id)
    {
        this.isDone = false;

        Debug.Log("You: " + subQuests.Count);

        for(int i = 0; i < subQuests.Count; i++)
        {
            subQuests[i].Initialize(this.id);
        }

    }

    private void QuestDone()
    {
        this.isDone = true;
    }

    public void SubQuestDone(int id)
    {
        GetSubquest(id).Done();
        CheckIfDone();
    }


    private SubQuest GetSubquest(int id)
    {
        foreach (SubQuest s in subQuests)
        {
            if (s.id == id)
            {
                return s;
            }
        }

        return null;
    }


    private void CheckIfDone()
    {
        foreach(SubQuest s in subQuests)
        {
            if (!s.isDone)
                return;
        }

        isDone = true;

    }

    public bool isSubquestBeforeDone(int id)
    {

        if (id - 1 < 0)
            return true;

        return GetSubquest(id - 1).isDone;

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
