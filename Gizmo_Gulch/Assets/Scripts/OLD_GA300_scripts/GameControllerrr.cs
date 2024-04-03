using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerrr : MonoBehaviour
{
    public Turret turretScript;
    public Spawner spawnerScript;
    public static GameControllerrr instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
