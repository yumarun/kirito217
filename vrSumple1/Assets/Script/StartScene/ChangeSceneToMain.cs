using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneToMain : MonoBehaviour
{
    public void GoMainScene()
    {
        SceneManager.LoadScene("main1");
    }
}
