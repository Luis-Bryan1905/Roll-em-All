using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Speed at which the ball moves.")]
    public float moveSpeed = 5f;

    private Rigidbody rigid;

    [Tooltip("Smoothing factor for accelerometer input.")]
    public float smoothing = 0.1f;

    private Vector3 tilt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
   private void Update()
    {
       tilt = Input.acceleration;

       tilt = Vector3.Lerp(tilt, Input.acceleration, smoothing);         // Apply smoothing to reduce jitter

        MoveBall();
    }

    void MoveBall()
    {
       // tilt = Quaternion.Euler(90, 0, 0) * tilt;

        Vector3 movement = new Vector3
            (
                tilt.x * moveSpeed, // left right
                0f,
                tilt.y * moveSpeed // forward back
            );

        rigid.AddForce(movement, ForceMode.Acceleration);
    }
}
