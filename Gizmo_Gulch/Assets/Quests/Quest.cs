using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    [TextArea(3, 10)]
    public string description;
    public string[] objectives;
    public string[] rewards;
    public bool isActive;
    public bool isCompleted;
    public bool isFailed;

    // Add any additional fields or methods as needed
}
