using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public string sceneName = "SampleScene";
    void Start()
    {
        Debug.Log("loading " + sceneName);
    }
    public void LoadGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
