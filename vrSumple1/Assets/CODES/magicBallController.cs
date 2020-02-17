using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicBallController : MonoBehaviour
{
    float speed = 0.1f; // 魔法の飛んでいくスピード
    float startTime = 3.0f; // 開始から、魔法が飛んでいくまでの時間
    float timeKeeper = 0.0f; // 時間計測
    bool CanMagicMove = false; // 魔法が飛んでいくことができるか

    void Start()
    {
        
    }

    
    void Update()
    {
        // 開始と同時に時間計測スタート
        timeKeeper += Time.deltaTime;

        // 一定時間たったら魔法を動かすのを許可
        if (timeKeeper >= startTime)
        {
            transform.Translate(speed, 0, 0);
        }

        

        // 魔法が遠くへ行き過ぎたら魔法を壊す
        if (transform.position.x <= -100)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // 剣と当たったら魔法を壊す
        if (other.tag == "sword")
        {
            Destroy(gameObject);
        }
    }

}
