using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    
    public Car car;
    public float alignToGroundTime;
    public LayerMask groundLayer;

    private float moveInput;
    private float turnInput;
    private bool isCarGrounded;
    
    void Start()
    {
        // Detach Sphere from car
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get Input
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        // Calculate Turning Rotation
        float newRot = turnInput * car.turnSpeed * Time.deltaTime * moveInput;

        // Set Cars Position to Our Sphere
        // transform.position = rb.transform.position;

        // Raycast to the ground and get normal to align car with it.
        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);

        // Rotate Car to align with ground
        Quaternion toRotateTo = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotateTo, alignToGroundTime * Time.deltaTime);

        // Calculate Movement Direction
        moveInput *= moveInput > 0 ? car.forwardAcceleration : car.backwardAcceleration;

        if (isCarGrounded)
            transform.Rotate(0, newRot, 0, Space.World);
    }

    private void FixedUpdate()
    {
        if (isCarGrounded && rb.velocity.z < car.maxBackwardSpeed)
        {
            rb.AddForce(transform.forward * moveInput * car.forwardAcceleration, ForceMode.Acceleration); // Add Movement
            Debug.Log("Velocity = " + rb.velocity.z);
        }
        else
            rb.AddForce(transform.up * -200f); // Add Gravity
    }
}