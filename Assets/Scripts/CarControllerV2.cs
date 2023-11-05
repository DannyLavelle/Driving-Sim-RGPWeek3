using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CarControllerV2 : MonoBehaviour
{
    InputAction accelerate, brakePedal, turn,cameraToggle,pause;
    public WheelColliders colliders;
    public WheelMeshes meshes;
    public GameObject CamToggle;
    public GameObject Menu;
    public  float accelerateInput;
    public  float turnInput;
    public float brakeInput;
    
    float brakeButton;
    public float motorPower  ;
    public float brakePower  ;
    private float speed;
   
    public float slipAngle;
    private Rigidbody rb;
    [SerializeField]
    public AnimationCurve steeringCurve;
        // Start is called before the first frame update
    void Start()
    {
        rb =gameObject.GetComponent<Rigidbody>();
        GameManager.InputManager.inputActions.Drive.Accelerate.Enable();
        GameManager.InputManager.inputActions.Drive.BrakePedal.Enable();
        GameManager.InputManager.inputActions.Drive.Turn.Enable();
        GameManager.InputManager.inputActions.Drive.CameraToggle.Enable();
        GameManager.InputManager.inputActions.Drive.Pause.Enable();
    }
    private void OnEnable()
    {
        turn = GameManager.InputManager.inputActions.Drive.Turn;
        turn.Enable();

        accelerate = GameManager.InputManager.inputActions.Drive.Accelerate;
        accelerate.Enable();

        brakePedal = GameManager.InputManager.inputActions.Drive.BrakePedal;
        brakePedal.Enable();

        cameraToggle = GameManager.InputManager.inputActions.Drive.CameraToggle;
        cameraToggle.Enable();
        cameraToggle.performed += ToggleCameraScript;
        pause = GameManager.InputManager.inputActions.Drive.Pause;
        pause.Enable();
        pause.performed += PauseGame;
    }
    void ToggleCameraScript(InputAction.CallbackContext context)
    {
        MenuController pausepanel = Menu.GetComponent<MenuController>();
        if(pausepanel.IsGamePaused == false)
        {
            CameraToggle toggle = CamToggle.GetComponent<CameraToggle>();
            toggle.ToggleCamera();
        }
      
    }
    void PauseGame(InputAction.CallbackContext context)
    {
        MenuController pausepanel = Menu.GetComponent<MenuController>();
        pausepanel.CheckPause();

    }
    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;
        ApplyWheelPosition();
        checkInput();
        ApplyMotor();
        ApplySteering();
        ApplyBrake();
    }
    void checkInput()
    {
        accelerateInput = accelerate.ReadValue<float>() - (.5f*brakePedal.ReadValue<float>());
        brakeButton = brakePedal.ReadValue<float>();
        
        //Debug.Log(accelerateInput);
        turnInput = turn.ReadValue<Vector2>().x;
        slipAngle = Vector3.Angle(transform.forward,rb.velocity-transform.forward);
        if (slipAngle < 120f)
        {
           
            if (brakeButton > 0)
            {
                brakeInput = Mathf.Abs(brakeButton);
                accelerateInput = 0;
                
            }
            else
            {
                brakeInput = 0;
            }
        }
        else
        {
            brakeInput = 0;
        }
    }
    void ApplyMotor()
    {
        if (rb.velocity.magnitude <35)
        {
            colliders.brWheel.motorTorque = motorPower * accelerateInput;
            colliders.blWheel.motorTorque = motorPower * accelerateInput;
        }
        else
        {
            colliders.brWheel.motorTorque = 0;
            colliders.blWheel.motorTorque = 0;
        }
   
        //Debug.Log(colliders.brWheel.motorTorque);
        //Debug.Log(rb.velocity.magnitude);

    }
    void ApplyBrake()
    {
        colliders.frWheel.brakeTorque = brakeInput * brakePower * 0.7f;
        colliders.flWheel.brakeTorque = brakeInput * brakePower * 0.7f;
        //Debug.Log(brakeInput + " * " + brakePower + " * 0.7f" );
        colliders.brWheel.brakeTorque = brakeInput * brakePower * 0.3f;
        colliders.blWheel.brakeTorque = brakeInput * brakePower * 0.3f;
    }
    void ApplySteering()
    {

        float steeringAngle = turnInput * steeringCurve.Evaluate(speed);
        //Debug.Log(steeringCurve.Evaluate(speed));
        //if (slipAngle < 120f)
        //{
        //    steeringAngle += Vector3.SignedAngle(transform.forward, rb.velocity + transform.forward, Vector3.up);
        //}
        steeringAngle = Mathf.Clamp(steeringAngle, -90f, 90f);
        colliders.frWheel.steerAngle = steeringAngle;
        colliders.flWheel.steerAngle = steeringAngle;
    }
    void ApplyWheelPosition()
    {
        updateWheel(colliders.flWheel, meshes.flWheel);
        updateWheel(colliders.frWheel, meshes.frWheel);
        updateWheel(colliders.blWheel, meshes.blWheel);
        updateWheel(colliders.brWheel, meshes.brWheel);
    }
    void updateWheel(WheelCollider coll, MeshRenderer wheelMesh)
    {
        Quaternion quat;
        Vector3 position;
        coll.GetWorldPose(out position, out quat);
        wheelMesh.transform.position = position;
        wheelMesh.transform.rotation = quat;

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
