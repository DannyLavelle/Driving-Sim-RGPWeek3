using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int CurrentLevel;
    float timer = 0;
    bool startTimer = false;
    public TMP_Text timerText;
    public TMP_Text winTimer;
    public GameObject timerPanel;
    public GameObject firstPersonUi;
    public GameObject HUD;
    public GameObject winPanel;
    public GameObject PausePanel;
    public GameObject BestText;
    public Button resumeButton;
    bool uiActive = false;
    public bool IsGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        IsGamePaused = true;
        PauseControl();
        startTimer = true;
        timerPanel.SetActive(true);
        ActivateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
            updateTimerDisplay();
        }
    }
    public void toggleTimer()
    {
        if (startTimer)
        {
            startTimer = false;
        }
        else
        {
            startTimer = true;
        }
    }
    public void resetTimer()
    {
        timer = 0;
    }
    void updateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        if (timerText != null)
        {
            timerText.text = string.Format("Time: {0:D2}:{1:D2}", minutes, seconds);
        }
    }
    public void toggleFirstPersonUI()
    {
        if(uiActive)
        {
            firstPersonUi.SetActive(false);
            uiActive = false;
        }
        else
        {
            firstPersonUi.SetActive(true);
            uiActive = true;
        }
    }
    void PauseControl()//Toggles Pause/Unpause
    {
        switch (IsGamePaused)
        {
            case false:
            Time.timeScale = 0f;
            IsGamePaused = true;
            
            RemoveHUD();
            break;
            case true:
            Time.timeScale = 1f;
            IsGamePaused = false;
            
            ActivateHUD();
            break;
        }
    }
    void RemoveHUD()
    {
        HUD.SetActive(false);
    }
    void ActivateHUD()
    {
        HUD.SetActive(true);
    }
    public void WinSequence()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

       
        PauseControl();
        winTimer.text = string.Format("Time: {0:D2}:{1:D2}", minutes, seconds);
        
        winPanel.SetActive(true);
        saveScores();

    }
    void saveScores()
    {
        string nextLevelUnlocked = ("Level" + (CurrentLevel + 1) + "Unlocked");
        string levelTime = ("Level" + CurrentLevel + "Time");
        if(PlayerPrefs.GetInt(nextLevelUnlocked ) == 1)
        {
            if (timer < PlayerPrefs.GetFloat(levelTime))//Check if time beats his pb
            {

                PlayerPrefs.SetFloat(levelTime, timer);
                BestText.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(levelTime, timer);
            BestText.SetActive(true);
            PlayerPrefs.SetInt(nextLevelUnlocked, 1);
        }
       

        PlayerPrefs.Save();
    }
    public void CheckPause()
    {
        if (IsGamePaused == false )
        {
            PauseControl();
            PausePanel.SetActive(true);
            resumeButton.Select();

        }
        else if (IsGamePaused == true && PausePanel.activeSelf)
        {
            PauseControl();
            PausePanel.SetActive(false);
        }

    }

    public void OpenMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}


