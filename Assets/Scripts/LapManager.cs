using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LapManager : MonoBehaviour
{
    public int maxCheckpoints;
    public int maxLaps;
    int currentLaps = 0;
    int currentCheckpoints = 0;
    public GameObject[] Checkpoints;

    public void increaseCheckPoints()
    {
        currentCheckpoints++;
    }
    public void increaseLaps()
    {
        currentLaps++;
    }
    private void OnTriggerEnter3D(Collider other)
    {
      if(other.gameObject.tag == "Player" && currentCheckpoints == maxCheckpoints)
        {
            currentLaps++;
            currentCheckpoints = 0;
            for (int i = 0; i < Checkpoints.Length; i++)
            {
                Checkpoints[i].SetActive(true);
            }
            if (currentLaps == maxLaps)
            {
                //win logic here 
            }
        }
    }
}
