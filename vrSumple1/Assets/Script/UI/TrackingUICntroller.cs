using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrackingUICntroller : MonoBehaviour
{
    [SerializeField]
    StartCounter starcounter;
    [SerializeField]
    makeMagicArrowController makemagiccontroller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    public void OnStartButtonClicked(GameObject sender)
    {
        starcounter.StartCount();
        makemagiccontroller.OnStartButtonSelected();
        sender.SetActive(false);
    }

    public void OnRestartButtonClicked(GameObject sender)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        sender.SetActive(false);
    }

}
