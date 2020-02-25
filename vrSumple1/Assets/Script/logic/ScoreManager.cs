﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public makeMagicArrowController ArrowController;

    private int hitCount;
    public int HitCount
    {
        get {return hitCount;}
        set 
        {
            if (value == hitCount)
                return;
            
            hitCount = value;
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

    private void onSpawnCountChanged()
    {
        if (HitCount + UnHitCount >= MaxSpawnNumber)
        {
            StopGameLogic();
        }
    }
    public void StopGameLogic()
    {
        ArrowController.StopSpawnRoutine();
        HitCount = 0;
        UnHitCount = 0;
        Debug.Log("Game logic has ended.");
    }
}