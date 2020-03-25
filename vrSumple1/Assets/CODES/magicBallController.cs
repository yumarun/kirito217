using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//魔法弾生成時のSE
//魔法弾の挙動関連はここ

public class magicBallController : MonoBehaviour
{
    float speed = 20.0f; // 魔法の飛んでいくスピード
    float stayTime = 2.0f; // 
    float timeKeeper = 0.0f; // 時間計測
    public bool CanMagicMove = false; // 魔法が飛んでいくことができるか
    public AudioClip MagicApperBGM;
    GameObject player;

    void Start()
    {
        //Debug.Log("出現");
        StartCoroutine(PlayMagicApperBGM());
        player = GameObject.Find("OVRPlayerController");
    }

    
    void Update()
    {
        timeKeeper += Time.deltaTime;

        if (timeKeeper >= stayTime)
        {

            //transform.Translate(speed, 0, 0);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1.0f, player.transform.position.z) , speed * Time.deltaTime);

        }
        // 魔法が遠くへ行き過ぎたら魔法を壊す
        if (transform.position.x >= 25 || transform.position.y <= 2)
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
            ScoreManager.Instance.HitCount++;
            Destroy(gameObject);
        }
    }

    void PlayeApperBGM()
    {
        GetComponent<AudioSource>().PlayOneShot(MagicApperBGM);

    }

    private IEnumerator PlayMagicApperBGM()
    {
        yield return new WaitForSeconds(0.1f);
        PlayeApperBGM();
    }

}
