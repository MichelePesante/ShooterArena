using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [Header("Public variables")]
	public float movementSpeed;
	public float jumpSpeed;
    [HideInInspector] public Vector3 direction;
    private bool isJumping;

	private Rigidbody rb;
	private bool isRotateRight;

    private string horizontalInput;
    private string verticalInput;
    private KeyCode jumpInput;

    [Header("Ground Check")]
    public float sphereRadius;
    public LayerMask whatIsGround;
    public Transform position;


    private int playerLayer;

	private PlayerManager pm;

    Animator myAnim;

    void Start () {
		isJumping = false;
		movementSpeed = 0.2f;
		jumpSpeed = 22.5f;
		rb = gameObject.GetComponent<Rigidbody> ();
		if (!gameObject.GetComponent<Rigidbody> ())
			rb = gameObject.AddComponent<Rigidbody> ();
		rb.freezeRotation = true;
		direction = Vector3.right;
		isRotateRight = true;
		pm = GetComponent<PlayerManager> ();
        myAnim = GetComponentInChildren<Animator>();

        AssignPlayerInput();
    }

	void Update () {
	//	switch (pm.PlayerState) {
	//	case PlayerManager.State.IsGrounded:
	//		Jump ();
	//			break;
	//	case PlayerManager.State.IsJumping:
	//			break;
	//	case PlayerManager.State.IsFalling:
	//		Jump ();
	//			break;
	//	case PlayerManager.State.IsDead:
	//			break;
	//	default:
	//			break;
	//	}
		Jump ();
        Movement();
		IsGroundedCheck();

        rb.WakeUp();



    }

    /// <summary>
    /// funzione che controlla con un overlapsphere se si collide con il terreno, resetta isJumping a false
    /// </summary>
    void IsGroundedCheck()
    {
        Collider[] collidingObjects = Physics.OverlapSphere(position.position, sphereRadius, whatIsGround);

        for (int i = 0; i < collidingObjects.Length; i++)
        {
            if (collidingObjects[i].tag == "Ground")
            {
                isJumping = false;
                myAnim.SetBool("IsJumping", false);
            }

        }
    }

    //funzione di movento
    void Movement()
    {
        if (Input.GetAxisRaw(horizontalInput) == -1)
        {
            direction = Vector3.left;
            transform.position += direction * movementSpeed;
            if (isRotateRight)
            {
                transform.Rotate(0f, 180f, 0f);
                isRotateRight = false;
            }

            myAnim.SetBool("IsWalking", true);
        }
        if (Input.GetAxisRaw(horizontalInput) == 1)
        {
            direction = Vector3.right;
            transform.position += direction * movementSpeed;
            if (!isRotateRight)
            {
                transform.Rotate(0f, -180f, 0f);
                isRotateRight = true;
            }
            myAnim.SetBool("IsWalking", true);
        }

       if (Mathf.Abs(Input.GetAxisRaw(horizontalInput)) <= 0.7f)
       {
           myAnim.SetBool("IsWalking", false);
       }
    }

    //funzione di jump
    void Jump()
    {
		if (Input.GetKeyDown(jumpInput) && !isJumping)
        {
            rb.velocity = Vector3.up * jumpSpeed;
            isJumping = true;
            myAnim.SetBool("IsJumping", true);
        }

    //   if (isJumping)
    //   {
    //       Physics.IgnoreLayerCollision(playerLayer, 9, true);
    //
    //   }
    //   else
    //   {
    //       Physics.IgnoreLayerCollision(playerLayer, 9, false);
    //    }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (Input.GetAxis(verticalInput) == -1)
            {
                GetComponent<BoxCollider>().enabled = false;
                Invoke("ReenableCollider", 0.25f);
				isJumping = true;
            }
        }
    }

    void ReenableCollider()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    //funzione che assegna gli input dei controller a seconda del nome (numero) del player
    void AssignPlayerInput()
    {

        if (gameObject.name == "Player1")
        {
            horizontalInput = "Horizontal";
            verticalInput = "Vertical";
            jumpInput = KeyCode.Joystick1Button0;
            playerLayer = 12;
            gameObject.layer = playerLayer;
        }
        else if (gameObject.name == "Player2")
        {
            horizontalInput = "Horizontal2";
            verticalInput = "Vertical2";
            jumpInput = KeyCode.Joystick2Button0;
            playerLayer = 13;
            gameObject.layer = playerLayer;
        }
        else if (gameObject.name == "Player3")
        {
            horizontalInput = "Horizontal3";
            verticalInput = "Vertical3";
            jumpInput = KeyCode.Joystick3Button0;
            playerLayer = 14;
            gameObject.layer = playerLayer;
        }
        else if (gameObject.name == "Player4")
        {
            horizontalInput = "Horizontal4";
            verticalInput = "Vertical4";
            jumpInput = KeyCode.Joystick4Button0;
            playerLayer = 15;
            gameObject.layer = playerLayer;
        }
    }

    /*void OnCollisionEnter(Collision _collision) 
	{
		if (_collision.gameObject.tag == "Ground" && isJumping) 
		{
			isJumping = false;
		}
	}*/
}
