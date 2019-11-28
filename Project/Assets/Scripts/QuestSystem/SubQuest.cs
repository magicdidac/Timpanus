using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubQuest
{

    [HideInInspector] public int id { get; private set; }
    [HideInInspector] public bool isDone { get; private set; }

    [SerializeField] public string title;

    public void Initialize(int id)
    {
        this.id = id;
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
