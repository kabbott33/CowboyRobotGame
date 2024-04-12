using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int coinValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        coinValue = Random.Range(1, 6);
        this.transform.position = new Vector3(Random.Range(-18f, 18f), 0, Random.Range(-18f, 18f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
