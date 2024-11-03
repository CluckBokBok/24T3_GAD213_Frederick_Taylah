using System.Collections;
using UnityEngine;

namespace PlayerMovement.Base
{
    public class BaseMovement : MonoBehaviour
    {
        protected Rigidbody2D body;
        [SerializeField] private float move = 0f;
        [SerializeField] private float speed = 3f;
        [SerializeField] private float jumpForce;
        [SerializeField] private LayerMask groundLayer;
        protected bool touchingGround; 

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        protected void Update()
        {
            InitiateMovement();
            InitiateJumping();
        }

        //Function takes care of forward and backward movement, and ensures all movement stops when no input is detected
        protected void InitiateMovement()
        {
            
            move = 0f;

            
            if (Input.GetKey(KeyCode.A))
            {
                move = -1f;
            }

            else if (Input.GetKey(KeyCode.D))
            {
                move = 1f;
            }

            
            body.velocity = new Vector2(move * speed, body.velocity.y);

            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 6f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 3f;
            }
        }

      
        protected void InitiateJumping()
        {
            // Detects if the player is touching the ground and then allows jumping
            if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce = 8f);
                Debug.Log("You are jumping!");
            }

            CheckGrounded();
        }

        protected void CheckGrounded()
        {
            // Checks if the player is grounded
            touchingGround = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 1f),
                                               new Vector2(transform.position.x + 0.5f, transform.position.y - 1.1f),
                                               groundLayer);
        }

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }
    }
}
