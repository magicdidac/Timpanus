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

    public void QuestDone(int id)
    {
        foreach(Quest q in quests)
        {
            if(q.id == id)
            {
                q.QuestDone();
                return;
            }
        }
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

    public PlayerController GetPlayer()
    {
        if (player == null)
            player = GameObject.FindObjectOfType<PlayerController>();

        return player;
    }

}
