using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Evidence_Manager_V2 : MonoBehaviour
{
    public static Evidence_Manager_V2 instance;
    public Flowchart flowchart;

    public AudioClip ding;

    public TextMeshProUGUI newEvidenceNotification;

    void Start()
    {
        instance = this;
    }

    public void ActivateEvidence()
    {
        int ID = flowchart.GetIntegerVariable("evidenceNumber");
        Node_Manager_V2.instance.AddNode(ID);

        if (!(Node_Manager_V2.instance.activeNodes.Contains(ID)))
        {
            ActivateEvidenceNotification();
        }

    }
    public void ActivateEvidenceNotification()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        newEvidenceNotification.gameObject.SetActive(true);
        Invoke("DeactivateEvidenceNotification", 2f);
    }

    public void DeactivateEvidenceNotification()
    {
        newEvidenceNotification.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
