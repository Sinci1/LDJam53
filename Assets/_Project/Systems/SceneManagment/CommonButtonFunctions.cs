using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonButtonFunctions : MonoBehaviour
{
    public void LoadScene(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }
    public void PlayGame(){
        bool firstTime = true;
        if (firstTime) { SceneManager.LoadScene("Level1"); return; }
        SceneManager.LoadScene("LevelSelect");
    }
}
