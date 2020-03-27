using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinishControll : MonoBehaviour
{
    public GameObject FinishText;
    public GameObject ReloadButton;
    public ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (scoreManager.HitCount == scoreManager.MaxSpawnNumber)
        {
            FinishText.GetComponent<Text>().text = "Game Clear! 動画が流れます!";
            ReloadButton.SetActive(true);
        }
        else if (scoreManager.HitCount + scoreManager.UnHitCount >= scoreManager.MaxSpawnNumber)
        {
            FinishText.GetComponent<Text>().text = "Game Over...";
            ReloadButton.SetActive(true);
        }
    }
}
