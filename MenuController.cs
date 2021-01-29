using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnButtonPlayGame() {
        SceneManager.LoadScene("Main");
    }
    public void OnButtonLevel2() {
        SceneManager.LoadScene("Level2");
    }
    public void OnButtonResetLevel1() {
        SceneManager.LoadScene("Main");
    }
    public void OnButtonResetLevel2() {
        SceneManager.LoadScene("Level2");
    }
    public void OnButtonResetLevel3() {
        SceneManager.LoadScene("Level3");
    }
    public void OnButtonLevel3() {
        SceneManager.LoadScene("Level3");
    }
    public void QuitGame() {
        Application.Quit();
    }
}

