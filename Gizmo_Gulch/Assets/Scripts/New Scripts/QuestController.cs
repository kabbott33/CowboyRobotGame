using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class QuestController : MonoBehaviour
{
    List<Quest> questList = new List<Quest>();
    // Start is called before the first frame update
    void Start()
    {
        Quests  CurQuest = new Quests();
        CurQuest.QuestTitle = "Test";
       // questList.Add(CurQuest);
    }

    // Update is called once per frame
    void Update()
    {
        //questList.Add()
    }
}

public class Quests 
{
    public string QuestTitle;
    public float reward;
    public string identifier;
}