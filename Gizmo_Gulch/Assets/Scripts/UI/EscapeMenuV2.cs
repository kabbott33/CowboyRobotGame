using DG.Tweening;
using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuV2 : MonoBehaviour
{
    //public float fadeInTime = 0.5f;

    //public float bounceTime;
    //Sequence sequence;
    public GameObject pauseMenu;
    //public bool canTogglePause = true;

    public Flowchart flowchart;
    public GameObject tabMenu;

    public SunMover_V2 sunMover;

    //private CanvasGroup canvasGroup;
    //public float stopTime;
    // Start is called before the first frame update
    void Start()
    {
        //canvasGroup = this.GetComponent<CanvasGroup>();
        pauseMenu.gameObject.SetActive(false);
        /*
        this.transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence();
        canvasGroup.alpha = 0f; 
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseScreen();
        }
    }

    public void TogglePauseScreen()
    {
        if (!(pauseMenu.activeInHierarchy))
        {
            pauseMenu.gameObject.SetActive(true);
            // Time.timeScale = 0;
            tabMenu.gameObject.SetActive(false);


            Debug.Log("haha");

            EventController.instance.UnlockCursor();
            EventController.instance.PauseTime();
        }
        else if (pauseMenu.activeSelf)
        {

            pauseMenu.gameObject.SetActive(false);

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
        /*
        this.transform.DOScale(Vector3.zero, fadeInTime);
        canvasGroup.DOFade(0f, fadeInTime);
        */
        // stopTime = (fadeInTime);
    }



    /*
    private IEnumerator WaitForPauseMenu()
    {
        yield return new WaitForSeconds(stopTime);
        canTogglePause = true;
    }

    */
}
