using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleController : MonoBehaviour {
    [SerializeField] float movementSpeed = 2f;
    Rigidbody2D moleRb;
    Animator moleAnimator;
    float horizontalMove = 0;
    float verticalMove = 0;
    bool facingRight = true;
    bool facingFront = true;
    public GameObject targetPatrol1;
    public GameObject targetPatrol2;
    GameObject swapTarget;
    public static MoleController instance;

    private void Awake()
    {
        moleRb = GetComponent<Rigidbody2D>();
        moleAnimator = GetComponent<Animator>();
        instance = this;
    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (((targetPatrol1.transform.position.y - this.transform.position.y) >= 0.5f) || ((targetPatrol1.transform.position.y - this.transform.position.y) <= -0.5f))
        {
            horizontalMove = 0;
            if ((targetPatrol1.transform.position.y - this.transform.position.y) >= 0.5f)
            {
                verticalMove = 1;
            }
            else
            {
                verticalMove = -1;
            }
            moleAnimator.SetFloat("MovementSpeed", Mathf.Abs(verticalMove));
        }
        if (((targetPatrol1.transform.position.x - this.transform.position.x) >= 0.5f) || ((targetPatrol1.transform.position.x - this.transform.position.x) <= -0.5f))
        {
            verticalMove = 0;
            if ((targetPatrol1.transform.position.x - this.transform.position.x) >= 0.5f)
            {
                horizontalMove = 1;
            }
            else
            {
                horizontalMove = -1;
            }
            moleAnimator.SetFloat("MovementSpeed", Mathf.Abs(horizontalMove));
        }
        //verticalMove = Input.GetAxisRaw("Vertical");
        //horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Move(verticalMove, horizontalMove);
    }

    void Move (float verticalDirection, float horizontalDirection)
    {
        if (verticalDirection != 0)
        {
            moleRb.velocity = new Vector2(moleRb.velocity.x, verticalMove * movementSpeed);
            moleAnimator.SetBool("VerticalInput", true);
            moleAnimator.SetBool("HorizontalInput", false);
            moleAnimator.SetBool("FacingFront", facingFront);
            if (verticalDirection == 1 && facingFront == true)
            {
                facingFront = false;
            }
            else if (verticalDirection == -1 && facingFront == false)
            {
                facingFront = true;
            }
        }
        else
        {
            moleRb.velocity = new Vector2(moleRb.velocity.x, 0f);
        }

        if (horizontalDirection != 0)
        {
            moleRb.velocity = new Vector2(horizontalMove * movementSpeed, moleRb.velocity.y);
            moleAnimator.SetBool("HorizontalInput", true);
            moleAnimator.SetBool("VerticalInput", false);
            moleAnimator.SetBool("FacingFront", false);
            if (horizontalDirection == 1 && facingRight == false)
            {
                Flip();
            }
            else if (horizontalDirection == -1 && facingRight == true)
            {
                Flip();
            }
        }
        else
        {
            moleRb.velocity = new Vector2(0f, moleRb.velocity.y);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }

    public void SwapTarget()
    {
        swapTarget = targetPatrol1;
        targetPatrol1 = targetPatrol2;
        targetPatrol2 = swapTarget;
    }
}
