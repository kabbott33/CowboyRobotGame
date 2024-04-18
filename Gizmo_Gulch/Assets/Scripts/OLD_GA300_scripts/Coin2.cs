using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Coin2 : MonoBehaviour
{
    public int coinValue = 1;
    private bool hasBeenCollected = false;
    public UnityEvent onCollect;
    // Start is called before the first frame update
    void Start()
    {
        coinValue = Random.Range ( 1, 10);
        this.transform.position = new Vector3(Random.Range(-18f, 18f), 0, Random.Range(-18f, 18));

        if (hasBeenCollected )
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        onCollect?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
