using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMain : MonoBehaviour
{
    public bool CanPushBbutton = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanPushBbutton && OVRInput.GetDown(OVRInput.Button.Two)) {
            SceneManager.LoadScene("main1");
        }
    }
}
