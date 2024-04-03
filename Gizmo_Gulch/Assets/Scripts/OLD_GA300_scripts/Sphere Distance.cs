using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SphereDistance : MonoBehaviour
{
    public int distance;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - distance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
