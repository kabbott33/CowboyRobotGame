using DG.Tweening;
using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabMenuV2 : MonoBehaviour
{
    //public float fadeInTime = 0.5f;

    public GameObject tabMenu;
    //public float bounceTime;
    //Sequence sequence;

    //public bool canTogglePause = true;

    public Flowchart flowchart;
    public GameObject pauseMenu;
    public GameObject folderMenu;
    public GameObject insideFolderMenu;
    //private CanvasGroup canvasGroup;
    //public float stopTime;
    // Start is called before the first frame update

    public SunMover_V2 sunMover;
    void Start()
    {
        //canvasGroup = this.GetComponent<CanvasGroup>();
        tabMenu.gameObject.SetActive(false);
        /*
        this.transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence();
        canvasGroup.alpha = 0f; 
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleTabScreen();
        }
    }

    public void ToggleTabScreen()
    {
        if (!(tabMenu.activeInHierarchy))
        {
            tabMenu.gameObject.SetActive(true);
            folderMenu.gameObject.SetActive(true);
            // Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(false);


            EventController.instance.UnlockCursor();
            EventController.instance.PauseTime();
        }
        else if (tabMenu.activeSelf)
        {
            insideFolderMenu.gameObject.SetActive(false);
            tabMenu.gameObject.SetActive(false);
            folderMenu.gameObject.SetActive(false);

            /*
            if (!(sunMover.isRotating))
            {
                Time.timeScale = 1;
            }
            else if (sunMover.isRotating)
            {
                EventController.instance.LockCursor();
            }
            */

            if ((flowchart.GetBooleanVariable("isTalking")) == false)
            {
                EventController.instance.ResumeTime();
                EventController.instance.LockCursor();
            }
            /*
            this.transform.DOScale(Vector3.zero, fadeInTime);
            canvasGroup.DOFade(0f, fadeInTime);
            */
            // stopTime = (fadeInTime);
        }
    }



    /*
    private IEnumerator WaitForPauseMenu()
    {
        yield return new WaitForSeconds(stopTime);
        canTogglePause = true;
    }

    */
}
