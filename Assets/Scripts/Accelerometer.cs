using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Speed at which the ball moves.")]
    public float moveSpeed = 5f;

    [Tooltip("Maximum Speed at which the ball moves.")]
    public float maxSpeed = 15f;

    private Rigidbody rigid;

    [Tooltip("Smoothing factor for accelerometer input.")]
    public float smoothing = 0.1f;

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

        Debug.Log("Speed = " + rigid.linearVelocity.magnitude);
    }

    private static Quaternion GyroToUnity(Quaternion q) //source: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Gyroscope.html
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
