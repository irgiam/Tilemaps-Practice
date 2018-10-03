using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroController : MonoBehaviour {

    [SerializeField] float movementSpeed = 2f;
    float horizontalMove = 0;
    float verticalMove = 0;
    Animator heroAnimator;
    bool facingRight = true;
    bool facingFront = true;
    Rigidbody2D heroRigidBody;
    [SerializeField] float staminaBar = 100;
    public Slider staminaSlider;

    private void Awake()
    {
        heroAnimator = GetComponent<Animator>();
        heroRigidBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (verticalMove <= 0.5f && verticalMove >= -0.5f)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            heroAnimator.SetFloat("MovementSpeed", Mathf.Abs(horizontalMove * movementSpeed));
        }
            
        if (horizontalMove <= 0.5f && horizontalMove >= -0.5f)
        {
            verticalMove = Input.GetAxisRaw("Vertical");
            heroAnimator.SetFloat("MovementSpeed", Mathf.Abs(verticalMove * movementSpeed));
        }
        //Debug.Log(horizontalMove);
        if (staminaBar >= 100)
        {
            staminaBar = 100;
        }
        if (staminaBar <= 0)
        {
            staminaBar = 0;
        }
        //staminaBar += 1;
        staminaSlider.value = staminaBar;
    }

    private void FixedUpdate()
    {
        if (horizontalMove != 0)
        {
            heroRigidBody.velocity = new Vector2(horizontalMove * movementSpeed, heroRigidBody.velocity.y);   
            heroAnimator.SetBool("HorizontalInput", true);
            heroAnimator.SetBool("FacingFront", false);
            if (horizontalMove == 1 && facingRight == false)
            {
                Flip();
            }
            else if (horizontalMove == -1 && facingRight == true)
            {
                Flip();
            }
            //NEVER USE TRANSLATION TO MOVE AN OBJECT IF YOU WANT TO USE COLLIDER
            //this.transform.Translate(Vector2.right * movementSpeed * horizontalMove * Time.deltaTime);
            heroAnimator.SetBool("VerticalInput", false);
            staminaBar -= Mathf.Abs(horizontalMove);
        }
        else
        {
            heroRigidBody.velocity = new Vector2(0f, heroRigidBody.velocity.y);
            staminaBar += 0.01f;
        }

        if (verticalMove != 0)
        {
            heroRigidBody.velocity = new Vector2(heroRigidBody.velocity.x, verticalMove * movementSpeed);
            heroAnimator.SetBool("FacingFront", facingFront);
            heroAnimator.SetBool("VerticalInput", true);
            if (verticalMove == 1 && facingFront == true)
            {
                facingFront = false;
            }
            else if (verticalMove == -1 && facingFront == false)
            {
                facingFront = true; 
            }
            //this.transform.Translate(Vector2.up * movementSpeed * verticalMove * Time.deltaTime);
            heroAnimator.SetBool("HorizontalInput", false);
            staminaBar -= Mathf.Abs(verticalMove);
        }
        else
        {
            heroRigidBody.velocity = new Vector2(heroRigidBody.velocity.x, 0f);
            staminaBar += 0.01f;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }
}
