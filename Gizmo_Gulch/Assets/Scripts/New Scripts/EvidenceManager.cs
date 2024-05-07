using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EvidenceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static EvidenceManager instance;
    public Flowchart flowchart;
    public int listCount;
    public List<GameObject> evidenceList;

    public AudioClip ding;

    public TextMeshProUGUI newEvidenceNotification;

    void Start()
    {
        instance = this;
    }

    public void ActivateEvidence()
    {
        int nombre = flowchart.GetIntegerVariable("evidenceNumber");
        evidenceList[nombre].SetActive(true);

        string name = evidenceList[nombre].name;

         if (!(NodeBoardManager.instance.activeNodes.Contains(name)))
       //if (!((evidenceList[nombre]).activeSelf))
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
