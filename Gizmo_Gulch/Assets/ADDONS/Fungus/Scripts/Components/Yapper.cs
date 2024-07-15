using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yapper : MonoBehaviour
{
    public Transform mouthOpen;
    public Transform mouthClose;
    public GameObject jaw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yap()
    {
        Debug.Log("yapperino");
        StartCoroutine("MoveJaw");
    }
    public IEnumerator MoveJaw()
    {
        jaw.transform.rotation = mouthOpen.transform.rotation;
        yield return new WaitForSeconds(0.2f);
        jaw.transform.rotation = mouthClose.transform.rotation;
    }
}
