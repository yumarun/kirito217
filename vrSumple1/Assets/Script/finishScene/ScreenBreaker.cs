using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBreaker : MonoBehaviour
{
    float timeKeeper = 0;
    public float MovieStopTime = 42.5f;
    public GameObject Screen1;
    

    // Update is called once per frame
    void Update()
    {
        timeKeeper += Time.deltaTime;
        if (timeKeeper >= MovieStopTime)
        {
            GetComponent<ReturnMain>().CanPushBbutton = true;
            Destroy(Screen1);
        }
    }
}
