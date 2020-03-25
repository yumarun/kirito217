using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//OVRPlayerControllerの子のStartCountTextに入ってる
//スタートボタン押した直後の動作はここで定義


public class StartCounter : MonoBehaviour
{
    // Start is called before the first frame update
    Text thistext;
    public AudioClip SoundButtleBGM;
    //GameObject tmp;
    public GameObject EnemyList;

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
        StartCoroutine(StartBGM());

        StartCoroutine(StartCountRoutine());

        StartCoroutine(IsActiveEnemy());
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
        //Destroy(gameObject); BGM再生の時に途中で切れちゃう
        //gameObject.SetActive(false);
        GetComponent<Text>().text = "";
    }
    private IEnumerator StartBGM()
    {
        yield return new WaitForSeconds(3.0f);
        GetComponent<AudioSource>().PlayOneShot(SoundButtleBGM);
    }

    private IEnumerator IsActiveEnemy()
    {
        yield return new WaitForSeconds(3.0f);
        EnemyList.SetActive(true);

    }



}
