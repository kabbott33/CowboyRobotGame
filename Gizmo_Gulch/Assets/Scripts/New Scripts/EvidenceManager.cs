using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EvidenceManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Flowchart flowchart;
    public int listCount;
    public List<GameObject> evidenceList;

    public AudioClip ding;

    public TextMeshProUGUI newEvidenceNotification;

    void Start()
    {
        
    }

    public void ActivateEvidence()
    {
        int nombre = flowchart.GetIntegerVariable("evidenceNumber");
        evidenceList[nombre].SetActive(true);

         if (!NodeBoardManager.instance.activeNodes.Contains((evidenceList[nombre]).name))
       //if (!((evidenceList[nombre]).activeSelf))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            newEvidenceNotification.gameObject.SetActive(true);
            Invoke("DeactivateEvidenceNotification", 2f);
        }

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
