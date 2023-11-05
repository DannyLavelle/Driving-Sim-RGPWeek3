using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraToggle : MonoBehaviour
{
    public GameObject firstPerson;
    public GameObject firstPersonUI;
    public GameObject thirdPerson;
    bool isFirstPerson = false;
    private void Start()
    {
        ToggleCamera();
    }
    public void ToggleCamera()
    {
        
        if(isFirstPerson)
        {
            firstPerson.SetActive(false);
            firstPersonUI.SetActive(false);
            thirdPerson.SetActive(true);
            isFirstPerson = false;
        }
        else
        {
            thirdPerson.SetActive(false);
            firstPerson.SetActive(true);
            firstPersonUI.SetActive(true);
            isFirstPerson = true;
        }
    }
}
