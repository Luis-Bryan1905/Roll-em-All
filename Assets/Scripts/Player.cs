using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Accelerometer code from https://www.youtube.com/watch?v=dO_YrCV7uk8

    [Header("Debug Settings")]
    [Tooltip("Display Gyro and Accelerometer debug logs.")]
    public bool debug = true;

    [Header("Gyro Movement Settings")]
    [Tooltip("Speed at which the ball moves.")]
    public float moveSpeed = 5f;

    [Tooltip("Maximum Speed at which the ball moves.")]
    public float maxSpeed = 15f;

    private Rigidbody rigid;

    [Tooltip("Smoothing factor for accelerometer input.")]
    public float smoothing = 0.1f;

    [Header("Accelerometer Jump Settings")]
    public InputAction jumpAction;

    [Tooltip("Can Player Jump?")]
    public bool canJump = true;

    [Tooltip("Shake Threshold")]
    public float maxShake = 5.0f;

    [Tooltip("Jump Cooldown")]
    public float jumpCooldown = 3.0f;

    [Tooltip("Jump Force")]
    public float jumpForce = 3.0f;

    private Quaternion rot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
       rot = Input.gyro.attitude;
       rot = Quaternion.Lerp(rot, Input.gyro.attitude, smoothing);         // Apply smoothing to reduce jitter

       MoveBall();

        Vector3 acceleration = Input.acceleration;

        if (acceleration.sqrMagnitude >= maxShake && canJump || jumpAction.IsPressed() && canJump)
        {
            JumpBall();
        }
    }

    void MoveBall()
    {
        Vector3 tilt =  rot * Vector3.forward;

        Vector3 movement = new Vector3
            (
                tilt.x * moveSpeed, // left right
                0f,
                tilt.y * moveSpeed // forward back
            );

        rigid.AddForce(movement, ForceMode.Acceleration);

        // Limit maximum speed
        if (rigid.linearVelocity.magnitude > maxSpeed)
        {
            rigid.linearVelocity = rigid.linearVelocity.normalized * maxSpeed;
        }

        // Limit minimum speed -  WIP NOT WORKING??
        if (rigid.linearVelocity.magnitude < 0.0f)
        {
            rigid.linearVelocity = new Vector3 (0.0f, 0.0f, 0.0f);
        }

        if (debug == true)
        {
            Debug.Log("Gyro Speed = " + rigid.linearVelocity.magnitude);
            Debug.Log("Accelerometer = " + Input.acceleration);
        }
        
    }

    void JumpBall() // https://www.youtube.com/watch?v=NdGzaYs5mp4
    {
        if (debug == true)
        {
            Debug.Log("Jumped! " + Input.acceleration.sqrMagnitude);
        }

        rigid.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void CanJump()
    {
        canJump = true;
    }

    private static Quaternion GyroToUnity(Quaternion q) //source: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Gyroscope.html
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
