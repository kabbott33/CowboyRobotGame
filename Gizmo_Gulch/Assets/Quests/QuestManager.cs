using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    // Add methods to add, remove, update, and track quest progress

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
    }

    // Implement other methods as needed

    // Example method to complete a quest
    public void CompleteQuest(Quest quest)
    {
        quest.isCompleted = true;
        quest.isActive = false;
        // Add rewards to player inventory or perform other actions
    }
}
