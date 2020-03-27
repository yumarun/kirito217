using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//魔法弾との衝突判定
//床から落下した時の処理
public class CharacterCollision : MonoBehaviour
{

    void Update()
    {
        if (gameObject.transform.position.y <= -100)
        {
            Destroy(gameObject);
        }
    }

    public GameObject scoreM;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Magic")
        {
            Destroy(hit.gameObject);
            scoreM.GetComponent<ScoreManager>().UnHitCount++;
        }
    }
    
}
