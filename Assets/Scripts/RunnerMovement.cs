using UnityEngine;

public class RunnerMovement : MonoBehaviour
{
    public float forwardSpeed = 8f;
    public float laneDistance = 2f;
    public float laneSpeed = 10f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private int currentLane = 1;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Switch lanes
        if (Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane = Mathf.Max(0, currentLane - 1);
        }

        if (Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane = Mathf.Min(2, currentLane + 1);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce,
                ForceMode.Impulse);

            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Run forward automatically
        Vector3 velocity = rb.linearVelocity;
        velocity.z = forwardSpeed;
        rb.linearVelocity = velocity;

        // Move toward the selected lane
        float targetX = (currentLane - 1) * laneDistance;

        Vector3 position = rb.position;
        position.x = Mathf.MoveTowards(
            position.x,
            targetX,
            laneSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}