using System.Collections;
using UnityEngine;

namespace PlayerMovement.Base
{
    public class BaseMovement : MonoBehaviour
    {
        protected Rigidbody2D body;
        private float move = 0f;
        [SerializeField] private float speed = 3f;
        [SerializeField] private float jumpForce = 8f;
        [SerializeField] private LayerMask groundLayer;
        protected bool touchingGround;

        // Start is called before the first frame update
        void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }


        // Update is called once per frame
        protected void Update()
        {
            InitiateMovement();
            InitiateJumping();
        }

        //Enables forward + backward movement, stops movement if no input is detected. 
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

        //Checks if player is touching the ground before initiating a jump
        protected void InitiateJumping()
        {
            if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                Debug.Log("You are jumping!");
            }

            CheckGrounded();
        }

        //A physics overlap that searches for the ground layer mask to ensure player is touching the ground 
        protected void CheckGrounded()
        {
            touchingGround = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 1f),
                                                   new Vector2(transform.position.x + 0.5f, transform.position.y - 1.1f),
                                                   groundLayer);
        }

        // Sets movement statistics based on the form being used by the player
        public void SetMovementStats(float newSpeed, float newJumpForce)
        {
            speed = newSpeed;
            jumpForce = newJumpForce;
        }
    }
}

