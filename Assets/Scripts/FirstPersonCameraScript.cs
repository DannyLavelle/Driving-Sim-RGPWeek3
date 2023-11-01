using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraScript : MonoBehaviour
{

    public GameObject Ui;
    // Start is called before the first frame update
    void Start()
    {
        MenuController menu = Ui.GetComponent<MenuController>();
        menu.toggleFirstPersonUI();
    }


}
