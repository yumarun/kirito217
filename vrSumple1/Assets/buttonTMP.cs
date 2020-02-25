using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonTMP : MonoBehaviour
{
    
    GameObject cnttext;
    // Start is called before the first frame update
    void Start()
    {
        cnttext = GameObject.Find("StartCountText");
        //StartCoroutine("StartCount");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public IEnumerator StartCount()
    {
        cnttext.GetComponent<Text>().text = "3";
        yield return new WaitForSeconds(1.0f);
        cnttext.GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1.0f);
        cnttext.GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1.0f);
        cnttext.GetComponent<Text>().text = "0";
        Destroy(cnttext);
    }
    */
    public void ONCLICK()
    {
        //StartCoroutine(cnttext.GetComponent<StartCounter>().StartCount());
        cnttext.GetComponent<StartCounter>().StartCount();
        Destroy(gameObject);
    }

}
