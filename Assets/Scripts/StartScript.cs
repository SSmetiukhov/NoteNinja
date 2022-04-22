using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject stopButton;

    //public GameObject pauseButton;
    public void StartPressed()
    {
        stopButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void StopPressed()
    {
     stopButton.SetActive(false);
     pauseMenuUI.SetActive(true);
     Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
