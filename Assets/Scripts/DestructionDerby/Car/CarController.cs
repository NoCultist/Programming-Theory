using UnityEngine;

namespace NoCultist.DestructionDerby
{
    public class CarController : MonoBehaviour
    {
        protected Rigidbody rb;
        public CarSettings car;
        public float alignToGroundTime = 2;

        private LayerMask groundLayer;
        [SerializeField] protected Transform centerOfMass;
        protected bool isGrounded;

        private float moveInput = 0;
        private float turnInput = 0;

        public void SetInput(float? vertical = null, float? horizontal = null)
        {
            if (vertical != null)
                moveInput = vertical.Value;
            if(horizontal != null)
                turnInput = horizontal.Value * vertical.Value;
        }

        public void Move()
        {
            
            float newRot = turnInput * car.TurnSpeed * Time.fixedDeltaTime;

            float inputForward = 1;
            //transform.position = rb.transform.position;
            switch (moveInput)
            {
                case < 0f:
                    inputForward = car.BackwardAcceleration * moveInput;
                    break;
                case > 0f:
                    inputForward = car.ForwardAcceleration * moveInput;
                    break;
                default:
                    inputForward = 0;
                    break;
            }
            
            if (isGrounded)
                transform.Rotate(0, newRot, 0, Space.World);


            if (isGrounded && rb.velocity.magnitude < car.MaxForwardSpeed)
            {
                rb.AddForce(transform.forward * inputForward, ForceMode.Acceleration); // Add Movement
            }
            else
                rb.AddForce(Vector3.up * -200f); // Add Gravity
        }

        private void Start()
        {
            groundLayer = CarManager.Settings.groundLayer;
            rb = GetComponent<Rigidbody>();
            rb.mass = car.Mass;
        }

        private void FixedUpdate()
        {
            if (centerOfMass != null)
                rb.centerOfMass = centerOfMass.localPosition;

            RaycastHit hit;
            isGrounded = Physics.Raycast(centerOfMass.position, -centerOfMass.up, out hit, 1f, groundLayer);

            Move();
        }
    }
}