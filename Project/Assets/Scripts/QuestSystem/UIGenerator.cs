using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGenerator : MonoBehaviour
{

    [SerializeField] private GameObject questPrefab = null;
    [SerializeField] private GameObject subQuestPrefab = null;

    [HideInInspector] private List<Quest> quests;

    private void Start()
    {
        this.quests = GameController.instance.quests;

        Generate();

    }

    private void Generate()
    {
        int lastSubQuestCount = 0;

        for(int i = 0; i < quests.Count; i++)
        {
            Quest q = quests[i];
            q.Initialize(i+1);

            RectTransform rectQuest = Instantiate(questPrefab, transform.position, Quaternion.identity).GetComponent<RectTransform>();
            rectQuest.SetParent(transform);
            rectQuest.anchoredPosition = new Vector2(0, -1 * (135 + (i * 135) + (lastSubQuestCount * 135)));
            rectQuest.GetComponent<UINoteLine>().quest = q;
            lastSubQuestCount = q.subQuests.Count;

            for(int j = 0; j < lastSubQuestCount; j++)
            {
                SubQuest subQ = q.subQuests[j];

                RectTransform rectSubQuest = Instantiate(subQuestPrefab, transform.position, Quaternion.identity).GetComponent<RectTransform>();
                rectSubQuest.SetParent(rectQuest);
                rectSubQuest.anchoredPosition = new Vector2(0, rectQuest.anchoredPosition.y - (67.5f + (j * 135)));
                rectSubQuest.GetComponent<UINoteLine>().subQuest = subQ;
            }

        }
    }

}
