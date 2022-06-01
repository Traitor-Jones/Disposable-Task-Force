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

    [SerializeField]
    private GameObject player;
    

    //Input Values
    private float thrust1D;
    private float strafe1D;
    private float roll1D;
    private float upDown1D;
    private Vector2 pitchYaw;

    AudioSource idleSound;
    AudioSource movementSound;
    AudioSource boostSound;

    void Awake(){
        float x_pos = PlayerPrefs.GetFloat("p_x");
        float y_pos = PlayerPrefs.GetFloat("p_y");
        float z_pos = PlayerPrefs.GetFloat("p_z");

        player.transform.position = new Vector3(x_pos, y_pos, z_pos);
        scene_start = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shipStats = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipHealth>();   
        currentBoostAmount = maxBoostAmount;

        idleSound = GameObject.FindGameObjectWithTag("PlayerIdleSound").GetComponent<AudioSource>();
        movementSound = GameObject.FindGameObjectWithTag("PlayerMovementSound").GetComponent<AudioSource>();

        PlayIdleMusic();
    }

    public void PlayIdleMusic(){
        idleSound.Play();
    }

    public void StopIdleMusic(){
        idleSound.Stop();
    }

    public void PlayMovementMusic(){
        movementSound.Play();
    }

    public void StopMovementMusic(){
        movementSound.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(scene_start) {
            HandleMovement();
            HandleBoosting();
        }
    }

    void Update(){
        if(scene_start) {
            // get the speed of the rigidbody
            float speed = rb.velocity.magnitude;

            // we need to play the idle sound if the ship is not moving and the idle sound is not playing already
            if(speed < 50.0f && !idleSound.isPlaying) {
                PlayIdleMusic();
            }

            // we need to stop the idle sound if the ship is moving and the idle sound is playing
            if(speed > 50.0f && idleSound.isPlaying) {
                StopIdleMusic();
            }

            // we need to play the movement sound if the ship is moving and the movement sound is not playing already
            if(speed > 50.0f && !movementSound.isPlaying) {
                PlayMovementMusic();
            }

            // we need to stop the movement sound if the ship is not moving and the movement sound is playing
            if(speed < 50.0f && movementSound.isPlaying) {
                StopMovementMusic();
            }
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
