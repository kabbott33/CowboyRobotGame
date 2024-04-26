using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenu : MonoBehaviour
{
    public GameObject sideMenu;
    public float moveTime;
    public Transform defaultPosition;
    public Transform endPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ToggleSideMenu();
        }
    }

    public void ToggleSideMenu()
    {
        sideMenu.transform.DOKill();

        if (sideMenu.transform.position == defaultPosition.position)
        {
            sideMenu.transform.DOMove(endPosition.position, moveTime);
        }
        else
        {
            sideMenu.transform.DOMove(defaultPosition.position, moveTime);
        }
    }
}
