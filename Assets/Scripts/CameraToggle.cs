using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraToggle : MonoBehaviour
{
    public GameObject firstPerson;
    public GameObject firstPersonUI;
    public GameObject thirdPerson;
    bool isFirstPerson = true;
    public void ToggleCamera(InputAction.CallbackContext context)
    {
        if(isFirstPerson)
        {
            firstPerson.SetActive(false);
            firstPersonUI.SetActive(false);
            thirdPerson.SetActive(true);
        }
        else
        {
            thirdPerson.SetActive(false);
            firstPerson.SetActive(true);
            firstPersonUI.SetActive(true);
            
        }
    }
}
