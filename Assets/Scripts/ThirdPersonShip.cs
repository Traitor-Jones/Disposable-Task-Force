using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody))]

public class ThirdPersonShip : MonoBehaviour
{
    [Header("=== Ship Movement Settings ===")]
    [SerializeField]
    private float yawTorque = 500f;
    [SerializeField]
    private float pitchTorque = 1000f;
    [SerializeField]
    private float rollTorque = 1000f;
    [SerializeField]
    private float thrust = 100f;
    [SerializeField]
    private float upThrust = 50f;
    [SerializeField]
    private float strafeThrust = 50f;
    
    [Header("=== Boost Settings ===")]
    [SerializeField]
    private float maxBoostAmount = 20f;
    [SerializeField]
    private float boostDeprecationRate = 0.25f;
    [SerializeField]
    private float boostRechargeRate = 0.5f;
    [SerializeField]
    private float boostMultiplier = 5f;
    private bool boosting = false;
    private float currentBoostAmount;

    [SerializeField, Range(0.001f, 0.999f)]
    private float thrustGlideReduction = 0.999f;
    [SerializeField, Range(0.001f, 0.999f)]
    private float upDownGlideReduction = 0.111f;
    [SerializeField, Range(0.001f, 0.999f)]
    private float leftRightGlideReduction = 0.111f;
    float glide, verticalGlide, horizontalGlide = 0f;

    public static bool scene_start;
    Rigidbody rb;
    ShipHealth shipStats;
    

    //Input Values
    private float thrust1D;
    private float strafe1D;
    private float roll1D;
    private float upDown1D;
    private Vector2 pitchYaw;

    // used to get the earth's position
    public GameObject earth;
    private Vector3 earthPosition;

    void Awake(){
        scene_start = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shipStats = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipHealth>();   
        currentBoostAmount = maxBoostAmount;

        earthPosition = earth.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        earthPosition = earth.transform.position;
        //Debug.Log("Earth's position: " + earth.transform.position);
        if(scene_start){
            HandleMovement();
            HandleBoosting();
        }
    }

    void HandleMovement()
    {
        //roll
        rb.AddRelativeTorque(Vector3.back * roll1D * rollTorque * Time.deltaTime, ForceMode.Acceleration);

        //pitch
        rb.AddRelativeTorque(Vector3.right * Mathf.Clamp(-pitchYaw.y, -1f, 1f) * pitchTorque * Time.deltaTime, ForceMode.Acceleration);

        //yaw
        rb.AddRelativeTorque(Vector3.up * Mathf.Clamp(pitchYaw.x, -1f, 1f) * yawTorque * Time.deltaTime, ForceMode.Acceleration);

        //thrust
        if(thrust1D > 0.1f || thrust1D < -0.1f)
        {
            float currentThrust;

            if(boosting)
            {
                currentThrust = thrust * boostMultiplier;
            }
            else
            {
                currentThrust = thrust;
            }

            rb.AddRelativeForce(Vector3.forward * thrust1D * currentThrust * Time.deltaTime);

            glide = thrust;
        }
        else
        {
            rb.AddRelativeForce(Vector3.forward * glide * Time.deltaTime);

            glide *= thrustGlideReduction;
        }

        
        if(upDown1D > 0.1f || upDown1D < -0.1f)
        {
            rb.AddRelativeForce(Vector3.up * upDown1D * upThrust * Time.fixedDeltaTime);

            verticalGlide = upDown1D * upThrust;
        }
        else
        {
            rb.AddRelativeForce(Vector3.up * verticalGlide * Time.fixedDeltaTime);

            verticalGlide *= upDownGlideReduction;
        }

        //strafe
        if(strafe1D > 0.1f || strafe1D < -0.1f)
        {
            rb.AddRelativeForce(Vector3.right * strafe1D * upThrust * Time.fixedDeltaTime);

            horizontalGlide = strafe1D * strafeThrust;
        }
        else
        {
            rb.AddRelativeForce(Vector3.right * horizontalGlide * Time.fixedDeltaTime);

            horizontalGlide *= leftRightGlideReduction;
        }
    }

    void HandleBoosting()
    {
        if(boosting && currentBoostAmount > 0f)
        {
            currentBoostAmount -= boostDeprecationRate;
            if(currentBoostAmount <= 0f)
            {
                boosting = false;
            }
        }
        else
        {
            if(currentBoostAmount < maxBoostAmount)
            {
                currentBoostAmount += boostRechargeRate;
            }
        }
    }

    #region Input Methods
    public void OnThrust(InputAction.CallbackContext context)
    {
        thrust1D = context.ReadValue<float>();
    }

    public void OnStrafe(InputAction.CallbackContext context)
    {
        strafe1D = context.ReadValue<float>();
    }

    public void OnUpDown(InputAction.CallbackContext context)
    {
        upDown1D = context.ReadValue<float>();
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        roll1D = context.ReadValue<float>();
    }

    public void OnPitchYaw(InputAction.CallbackContext context)
    {
        pitchYaw = context.ReadValue<Vector2>();
    }

    public void OnBoost(InputAction.CallbackContext context)
    {
        boosting = context.performed;
        Debug.Log("I pressed shift");
    }

    public void OnDamage(){
        Debug.Log("I pressed K");
    }
    #endregion
}

/*
Credit to Dan Pos - Game Dev Tutorials! 
Used some of his instructions to help implement the movement of the ship.
*/
