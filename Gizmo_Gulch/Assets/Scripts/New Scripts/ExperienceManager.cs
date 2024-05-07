using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager instance;
    // Start is called before the first frame update
    public int currentNodes = 0;

    public int availablePoints;

    public int requiredNodes = 6;
    void Start()
    {
        instance = this;
    }

    public void NodeAdded()
    {
        currentNodes++;
        if (currentNodes == requiredNodes)
        {
            availablePoints++;
            currentNodes = 0;

        }

    }

    public void ReduceAvailablePoints()
    {
        availablePoints--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
