using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObject : MonoBehaviour
{
    public string value = "I AM FROM MYOBJECT";
    public static MyObject instance;

    // Start is called before the first frame update
    void Awake ()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
