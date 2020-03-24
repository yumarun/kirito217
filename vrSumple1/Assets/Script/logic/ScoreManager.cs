using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ゲームが終了したときBGMを止める
//ゲームクリア時BGM流す

public class ScoreManager : SingleInstance<ScoreManager>
{
    public makeMagicArrowController ArrowController;
    public GameObject CountedScoreText;
    public GameObject StartCountertext;
    public AudioClip gameClearBGM;


    private int hitCount;
    public int HitCount
    {
        get {return hitCount;}
        set 
        {
            if (value == hitCount)
                return;
            
            hitCount = value;

            onHitCountChanged();
            onSpawnCountChanged();
            
        }
    }

    private int unHitCount;
    public int UnHitCount
    {
        get {return unHitCount;}
        set
        {
            if (value == unHitCount)
                return;

            unHitCount = value;
            onSpawnCountChanged();
        }
    }
    public int MaxSpawnNumber = 5;



    // Start is called before the first frame update
    void Start()
    {
        HitCount = 0;
        UnHitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onHitCountChanged()
    {
        
        CountedScoreText.GetComponent<Text>().text = "COUNT: " + HitCount.ToString();
    }

    private void onSpawnCountChanged()
    {
        if (HitCount + UnHitCount >= MaxSpawnNumber)
        {
            StopGameLogic();
            if (MaxSpawnNumber == hitCount)
            {
                GetComponent<AudioSource>().PlayOneShot(gameClearBGM);
            }
        }
    }
    public void StopGameLogic()
    {
        ArrowController.StopSpawnRoutine();
        //HitCount = 0;
        //UnHitCount = 0;

        // TODO: UIの更新

        StartCountertext.GetComponent<AudioSource>().Stop();
        Debug.Log("Game logic has ended.");
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}