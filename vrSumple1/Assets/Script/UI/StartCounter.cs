using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCounter : MonoBehaviour
{
    // Start is called before the first frame update
    Text thistext;
    //GameObject tmp;

    void Start()
    {
        
        thistext = GetComponent<Text>();
        //StartCoroutine("StartCount");
    }

    // Update is called once per frame
    void Update()
    {
        
        //thistext.text = (Time.deltaTime).ToString();
    }


    public void StartCount()
    {
        StartCoroutine(StartCountRoutine());
    }

    private IEnumerator StartCountRoutine()
    {
        GetComponent<Text>().text = "3";
        yield return new WaitForSeconds(1.0f);
        GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1.0f);
        GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1.0f);
        GetComponent<Text>().text = "0";
        Destroy(gameObject);
    }



}
