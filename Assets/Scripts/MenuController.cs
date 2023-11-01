using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    float timer = 0;
    bool startTimer = false;
    public TMP_Text timerText;
    public GameObject timerPanel;
    public GameObject firstPersonUi;
    bool uiActive = false;
    // Start is called before the first frame update
    void Start()
    {
        startTimer = true;
        timerPanel.SetActive(true);
        
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
}
