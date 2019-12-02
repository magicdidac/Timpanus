﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [HideInInspector] public static GameController instance;

    [SerializeField] private UIController uiController = null;
    [SerializeField] public AudioManager audioManager = null;
    [SerializeField] private PlayerController player;
    [Space]
    [SerializeField] public List<Quest> quests = new List<Quest>();



    [HideInInspector] public InputMaster controls;

    private void Awake()
    {

        Time.timeScale = 1;
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        controls = new InputMaster();
        controls.Enable();

        Debug.Log(quests[0].ToString());

    }

    private void Update()
    {
        foreach(Quest q in quests)
        {
            if (!q.isDone)
                return;
        }

        Win();

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


    public bool isQuestDone(int id)
    {
        Quest q = GetQuest(id);

        return q.isDone;

    }

    public bool isSubQuestDone(int quest, int subquest)
    {
        Quest q = GetQuest(quest);

        SubQuest s = q.GetSubquest(subquest);

        return s.isDone;

    }

    public void Die()
    {
        uiController.Die();
        player.Die();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    private void Win()
    {
        uiController.Win();
        player.Die();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
    }

}
