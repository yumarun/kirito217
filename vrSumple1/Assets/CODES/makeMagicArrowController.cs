using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMagicArrowController : MonoBehaviour
{
    public GameObject MagicArrowPrefab;
    public bool StartMakeArrow = false;
    float timeKeeper = 0;
    float IntervalMakeArrow = 1.0f;
    GameObject button1;

    int ArrowNumLimit = 6;
    int ArrowNum = 0;

    bool makeStop = false;
   
    // Start is called before the first frame update
    void Start()
    {
        button1 = GameObject.Find("b1");
    }

    // Update is called once per frame
    void Update()
    {
        //StartTimeKeeper += Time.deltaTime;
        if (button1.GetComponent<button1>().canmove)
        {
            timeKeeper += Time.deltaTime;
        }
        if (timeKeeper >= IntervalMakeArrow && !makeStop)
        {
            GameObject arrow = Instantiate(MagicArrowPrefab) as GameObject;
            arrow.transform.position = new Vector3(-44, Random.Range(3.0f, 5.0f), Random.Range(-3.0f, 0));
            timeKeeper = 0;
            ArrowNum++;

            if (ArrowNum >= ArrowNumLimit)
            {
                makeStop = true;
            }
        }
    }
}
