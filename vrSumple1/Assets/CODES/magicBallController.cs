using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicBallController : MonoBehaviour
{
    float speed = 0.2f; // 魔法の飛んでいくスピード
    float stayTime = 3.0f; // 
    float timeKeeper = 0.0f; // 時間計測
    public bool CanMagicMove = false; // 魔法が飛んでいくことができるか

    void Start()
    {
        
    }

    
    void Update()
    {
        timeKeeper += Time.deltaTime;

        if (timeKeeper >= stayTime)
        {

            transform.Translate(speed, 0, 0);
        }
        // 魔法が遠くへ行き過ぎたら魔法を壊す
        if (transform.position.x >= 25 )
        {
            ScoreManager mng = FindObjectOfType<ScoreManager>();
            mng.UnHitCount++ ;
            Destroy(gameObject);
        }

    }

    public void TrueCanMagicMove()
    {
        CanMagicMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 剣と当たったら魔法を壊す
        if (other.tag == "sword")
        {
            ScoreManager mng = FindObjectOfType<ScoreManager>();
            mng.HitCount++ ;
            Destroy(gameObject);
        }
    }

}
