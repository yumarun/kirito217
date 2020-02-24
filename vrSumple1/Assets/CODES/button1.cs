using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button1 : MonoBehaviour
{
    public bool canmove;
    GameObject magic;
    // Start is called before the first frame update
    void Start()
    {
        magic = GameObject.Find("magicarrow");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        Debug.Log("osareta");
        canmove = true;
        magic.GetComponent<magicBallController>().TrueCanMagicMove();

    }
    
}
