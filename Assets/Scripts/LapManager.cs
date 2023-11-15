using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LapManager : MonoBehaviour
{
    
    public int maxLaps;
    public int currentLaps = 0;
    public int currentCheckpoints = 0;
    public GameObject[] Checkpoints;
    public GameObject menu;
    public TMP_Text Laps;
    public int maxCheckpoints;

    private void Start()
    {
        updateLap();
        maxCheckpoints = Checkpoints.Length;
    }
    public void increaseCheckPoints()
    {
        currentCheckpoints++;
    }
    public void increaseLaps()
    {
        currentLaps++;
        updateLap();
    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "Player" && currentCheckpoints == maxCheckpoints)
        {
           increaseLaps();
            currentCheckpoints = 0;
            for (int i = 0; i < Checkpoints.Length; i++)
            {
                Checkpoints[i].SetActive(true);
            }
            if (currentLaps == maxLaps)
            {
                MenuController win = menu.GetComponent<MenuController>();
                win.WinSequence();
            }
        }
    }

    public void updateLap()
    {
        Debug.Log("lAPuPDATING");
        Laps.text = ("Lap : " + currentLaps + "/" + maxLaps);
    }
}
