using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject raceCar;

    void Start()
    {
        raceCar.SetActive(true);
    }
}
