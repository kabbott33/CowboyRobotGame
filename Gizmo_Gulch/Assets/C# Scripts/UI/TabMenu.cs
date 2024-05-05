using DG.Tweening;
using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabMenu : MonoBehaviour
{
    //public float fadeInTime = 0.5f;

    public GameObject tabMenu;
    //public float bounceTime;
    //Sequence sequence;

    //public bool canTogglePause = true;

    public Flowchart flowchart;
    public GameObject pauseMenu;
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
            EventController.instance.isPaused = true;
            // Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(false);

            EventController.instance.UnlockCursor();
            EventController.instance.PauseTime();
            }
        else if (tabMenu.activeSelf)
        {
            if (!(Input.GetKey(KeyCode.Mouse0)))
            {
                tabMenu.gameObject.SetActive(false);


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
                EventController.instance.isPaused = false;
                EventController.instance.ResumeTime();
            }
               
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
