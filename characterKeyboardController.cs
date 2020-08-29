using UnityEngine;

//Important Note!!!
//You need a character controller for this code to work

public class PlayerMovement : MonoBehaviour
{
    //You need to attach your camera 
    public Transform cam;

    //You need to attach your character controller
    public CharacterController controller;
    
    //walk speed of your character
    public float speed = 6f;
    
    //How smooth your character turn 
    public float TurnSmooth = 0.1f;
    
    //velocity of smooth turn
    float turnSmoothVelocity;
    private float verticalvelocity;
    
    //Gravity
    public float gravity = 9.8f;
    
    //Jump Force of your character
    public float jumpForce = 6f;
         
    void Update()
    {
        

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.01f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


        if (controller.isGrounded)
        {
            verticalvelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalvelocity = jumpForce;

            }
        }

        else
        {
            verticalvelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0, verticalvelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
    }
    
   
}
