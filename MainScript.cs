using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               
using UnityEngine.SceneManagement;  

public class MainScript : MonoBehaviour
{
    public static MainScript instance;
    public GameObject hudContainer, gameOverPanel;

    private float elapsedTime, startTime;
    public bool gamePlaying { get; private set; }
    public Text timeCounter, countdownText;
    public int countdownTime;
    
    TimeSpan timePlaying;


    private void Awake() {
        instance = this;
    }
    private void Start() {
        timeCounter.text = "Time: 00:00.00";
        gamePlaying = false;
        StartCoroutine(CountdownToStart());
    }
    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {

            countdownText.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }
        BeginGame();

        countdownText.text = "GO!";

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }
    private void BeginGame() {
        startTime = Time.time;
        gamePlaying = true;
    }
     private void Update()
    {
        if(gamePlaying) 
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;    
        }
    }
    public void EndGame() {
        gamePlaying = false;
        Invoke("ShowGameOverScreen", 1f);
    }
    private void ShowGameOverScreen() {
        gameOverPanel.SetActive(true);
        hudContainer.SetActive(false);
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
        gameOverPanel.transform.Find("FinalTimeText").GetComponent<Text>().text = timePlayingStr;
    }

     
        public void OnButtonLoadLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
