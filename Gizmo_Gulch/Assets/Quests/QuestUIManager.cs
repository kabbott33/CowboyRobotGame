using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    public Text questNameText;
    public Text questDescriptionText;
    public GameObject objectivePanel;
    public Text objectiveTextPrefab;

    public QuestManager questManager;

    public void UpdateQuestUI(Quest quest)
    {
        questNameText.text = quest.questName;
        questDescriptionText.text = quest.description;

        // Clear previous objectives
        foreach (Transform child in objectivePanel.transform)
        {
            Destroy(child.gameObject);
        }

        // Display current objectives
        foreach (string objective in quest.objectives)
        {
            Text objectiveText = Instantiate(objectiveTextPrefab, objectivePanel.transform);
            objectiveText.text = "- " + objective;
        }
    }
}
