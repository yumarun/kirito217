using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcVecPlayerToBlock : MonoBehaviour
{

    GameObject block;
    GameObject playr;
    GameObject mae;

    Vector3 VecPtoB;
    Vector3 VecFtoP;

    float angYOKO;
    float angTATE;
    
    void Start()
    {
        block = GameObject.Find("Cube");
        playr = GameObject.Find("OVRPlayerController");
        mae = GameObject.Find("mae");
    }

    
    void Update()
    {
        VecPtoB = block.transform.position - playr.transform.position;
        VecFtoP = mae.transform.position - playr.transform.position;

        angYOKO = Vector3.Angle(new Vector3(VecFtoP.x, VecFtoP.y, VecFtoP.z), new Vector3(VecPtoB.x, VecFtoP.y, VecPtoB.z));
        angTATE = Vector3.Angle(new Vector3(VecFtoP.x, VecFtoP.y, VecFtoP.z), new Vector3(VecFtoP.x, VecPtoB.y, VecPtoB.z));

        //Debug.Log(VecPtoB.x + " " + VecPtoB.y + " " + VecPtoB.z);
        //Debug.Log(VecFtoP.x + " " + VecFtoP.y + " " + VecFtoP.z);
        //Debug.Log("yoko:" + angYOKO + " tate:" + angTATE);
    }
}
