using UnityEngine;

public class CarController : MonoBehaviour
{
    protected Rigidbody rb;
    public CarSettings car;
    public float alignToGroundTime = 2;

    private LayerMask groundLayer;
    [SerializeField] protected Transform centerOfMass;
    protected bool isGrounded;  
   
    private void Start()
    {
        groundLayer = CarManager.Settings.groundLayer;
        rb = GetComponent<Rigidbody>();
        rb.mass = car.Mass;
    }

    public virtual void Move(){}

    private void FixedUpdate()
    {
        if(centerOfMass != null)
            rb.centerOfMass = centerOfMass.localPosition;

        RaycastHit hit;
        isGrounded = Physics.Raycast(centerOfMass.position, -centerOfMass.up, out hit, 1f, groundLayer);
    
        Move();
    }
}