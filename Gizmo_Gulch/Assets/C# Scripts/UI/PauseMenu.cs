using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public float fadeInTime = 0.5f;
    private bool canTogglePause = true;
    public float bounceTime;
    Sequence sequence;

    private CanvasGroup canvasGroup;
    public float stopTime;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = this.GetComponent<CanvasGroup>();
        this.transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence();
        canvasGroup.alpha = 0f;
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
        if ( canTogglePause == true)
        {
            this.transform.DOKill();
            sequence.Kill();
            sequence = DOTween.Sequence();
            if (this.transform.localScale == Vector3.zero)
            {
                EventController.instance.PauseTime();
                EventController.instance.UnlockCursor();

               sequence.Append(this.transform.DOScale(new Vector3(1.1f,1.1f,1.1f), fadeInTime));
               sequence.Append(this.transform.DOScale(Vector3.one, bounceTime));
                sequence.Insert(0f, canvasGroup.DOFade(1f, fadeInTime));

                   sequence.Play();

                //this.transform.DOScale(Vector3.one, fadeInTime);
            }
            else
            {
                EventController.instance.ResumeTime();
                EventController.instance.LockCursor();

                this.transform.DOScale(Vector3.zero, fadeInTime);
                canvasGroup.DOFade(0f, fadeInTime);
               // stopTime = (fadeInTime);
            }

            //canTogglePause = false;
            //StartCoroutine(WaitForPauseMenu());
        }

    }

    private IEnumerator WaitForPauseMenu()
    {
        yield return new WaitForSeconds(stopTime);
        canTogglePause = true;
    }
}
