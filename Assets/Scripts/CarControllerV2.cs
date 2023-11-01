using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarControllerV2 : MonoBehaviour
{
    InputAction accelerate, brakePedal, turn;
    public WheelColliders colliders;
    public WheelMeshes meshes;
        // Start is called before the first frame update
    void Start()
    {

        GameManager.InputManager.inputActions.Drive.Accelerate.Enable();
        GameManager.InputManager.inputActions.Drive.BrakePedal.Enable();
        GameManager.InputManager.inputActions.Drive.Turn.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateWheels()
    {

    }
    void updateWheel()
    {

    }
}
[System.Serializable]
public class WheelColliders
{
    public WheelCollider frWheel;
    public WheelCollider flWheel;
    public WheelCollider brWheel;
    public WheelCollider blWheel;
}
[System.Serializable]
public class WheelMeshes
{
    public MeshRenderer frWheel;
    public MeshRenderer flWheel;
    public MeshRenderer brWheel;
    public MeshRenderer blWheel;
}
