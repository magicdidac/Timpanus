using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
public class UINoteLine : MonoBehaviour
{

    public Quest quest = null;
    public SubQuest subQuest = null;

    [HideInInspector] private Animator anim;

    [SerializeField] private TMP_Text title = null;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
        if (quest.title != "")
            title.text = quest.title;
        else if (subQuest.title != "")
        {
            title.text = subQuest.title;
        }
        else
            Debug.LogWarning("WTF are you doing man!\nThis line doesnt have a quest or subquest assigned!", gameObject);

    }

    private void Update()
    {
        if (quest.title != "")
            anim.SetBool("isDone", quest.isDone);
        else if (subQuest.title != "")
            anim.SetBool("isDone", subQuest.isDone);
        else
            Debug.LogWarning("WTF are you doing man!\nThis line doesnt have a quest or subquest assigned!", gameObject);
    }

}
