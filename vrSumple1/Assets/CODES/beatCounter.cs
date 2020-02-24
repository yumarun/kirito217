using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatCounter : MonoBehaviour
{
    public int beatCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(beatCount);
    }
}
