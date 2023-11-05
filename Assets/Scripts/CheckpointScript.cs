using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public GameObject lapManager;

    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LapManager lap = lapManager.GetComponent<LapManager>();
            lap.increaseCheckPoints();
            Debug.Log("Increased Checkpoint");
            gameObject.SetActive(false);    
        }

    }
}
