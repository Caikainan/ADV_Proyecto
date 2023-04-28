using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    public float transitionTime = 0.2f;
    public float gravity = -9.81f;

    private CharacterController charactercontroller;
    private Animator animator;
    private Vector2 currentInput;
    private float verticalVelocity;
 

    void Start()
    {
        animator = GetComponent<Animator>();
        charactercontroller = GetComponent<CharacterController>();
    }

 

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 targetInput = new Vector2(moveHorizontal, moveVertical);
        currentInput = Vector2.Lerp(currentInput, targetInput, Time.deltaTime / transitionTime);

        animator.SetFloat("H", currentInput.x);
        animator.SetFloat("V", currentInput.y);

        if(charactercontroller.isGrounded)
        {
            verticalVelocity = 0;


        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        Vector3 gravityVector = new Vector3(0, verticalVelocity, 0);
        charactercontroller.Move(gravityVector * Time.deltaTime);

     }



}
