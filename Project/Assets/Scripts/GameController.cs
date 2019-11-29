using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public static GameController instance;

    [SerializeField] public List<Quest> quests = new List<Quest>();

    private PlayerController player;

    [HideInInspector] public InputMaster controls;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        controls = new InputMaster();
        controls.Enable();

        Debug.Log(quests[0].ToString());

    }

    public void SubquestDone(int questId, int subquestId)
    {
        foreach (Quest q in quests)
        {
            if(q.id == questId)
            {          
                q.SubQuestDone(subquestId);
                return;
            }
        }
    }

    public bool IsDone(int questId, int subquestId)
    {
        foreach(Quest q in quests)
        {
            if(q.id == questId)
            {
                foreach(SubQuest s in q.subQuests)
                {
                    if(s.id == subquestId)
                    {
                        return s.isDone;
                    }
                }
            }
        }

        return false;
    }

    public PlayerController GetPlayer()
    {
        if (player == null)
            player = GameObject.FindObjectOfType<PlayerController>();

        return player;
    }

    public Quest GetQuest(int id)
    {
        foreach(Quest q in quests)
        {
            if(q.id == id)
            {
                return q;
            }
        }

        return null;
    }

}
