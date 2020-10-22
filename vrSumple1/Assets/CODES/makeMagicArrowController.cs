using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMagicArrowController : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private StartCounter startCouter;
    [SerializeField]
    private float StartingDelayTime = 3.0f;
    [SerializeField]
    private float SpawnSpan = 1.0f;
    public GameObject MagicArrowPrefab;
   
    public bool IsActive{get; private set;} = false;
    public int SpawnedCount = 0;
    private void Start()
    {
        if (scoreManager == null)
            scoreManager = FindObjectOfType<ScoreManager>();
    }

    private IEnumerator spawnRoutine()
    {
        yield return new WaitForSeconds(StartingDelayTime);
        while(IsActive)
        {
            GameObject arrow = Instantiate(MagicArrowPrefab) as GameObject;
            arrow.transform.position = new Vector3(-44, Random.Range(5.3f, 6.2f), Random.Range(-2.6f, -0.3f));
            SpawnedCount++ ;
            if (SpawnedCount >= scoreManager.MaxSpawnNumber)
                break;
            yield return new WaitForSeconds(SpawnSpan);
        }
    }
    public void OnStartButtonSelected()
    {
        if (IsActive)
        {
            return;
        }

        IsActive = true;
        StartCoroutine(spawnRoutine());
     
    }
    public void StopSpawnRoutine()
    {
        IsActive = false;
    }
}
