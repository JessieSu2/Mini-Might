using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    //float doubleTapTime;
    //KeyCode lastKeyCode;

    // [SerializeField]
    // GameObject struck;
    
    // public Transform struckPoint;


    // public Transform attackPoint;
    // public float attackRange = 0.5f;
    // public LayerMask enemyLayers;

    public PlayerController controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    public GameObject Grappling;
    private GrapplingGun gun;
    [HideInInspector] public bool grappleCheck;

    // Start is called before the first frame update
    void Start()
    {
        gun = Grappling.GetComponent<GrapplingGun>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(horizontalMove == 0){
            animator.SetBool("Moving", false);
        }
        else{
            animator.SetBool("Moving", true);
        }
       

        if(horizontalMove == 0){
            animator.SetBool("Idle", true);
        }
        else{
            animator.SetBool("Idle", false);
        }

        
        if(Input.GetButtonDown("Jump") && controller.m_Grounded){
    
            jump = true;
            animator.SetTrigger("Jump");    
            //animator.Play("Player_Jump");
            animator.SetBool("Jumping", true);
   
        }

        if (Input.GetKey(KeyCode.Mouse0) && controller.m_Grounded && gun.isGrappling)
        {
            grappleCheck = true;
        }

        if (!controller.m_Grounded && gun.isGrappling && grappleCheck)
        {
            grappleCheck = false;
            animator.SetTrigger("Jump");
            //animator.Play("Player_Jump");
            animator.SetBool("Jumping", true);
        }

        if (controller.m_Grounded && !gun.isGrappling){
            OnLanding();
        }
        else{
            animator.SetBool("Jumping", true);
        }

        if(Input.GetButtonDown("Crouch")){
            crouch = true;
            animator.SetBool("Crouching", true);
            if (horizontalMove == 0)
            {
                animator.SetBool("Moving", false);
            }
            else
            {
                animator.SetBool("Moving", true);
            }
        }
        else if(Input.GetButtonUp("Crouch")){
            crouch = false;
            animator.SetBool("Crouching", false);
           
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;

         
    }

    public void OnLanding(){
        animator.SetBool("Jumping", false);
    }

    public void OnCrouching(bool isCrouching){
        //animator.SetBool("isCrouching", isCrouching);
        
    }
    
    
}
