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
    float speed = 15;

    private CharacterController charactercontroller;
    private Animator animator;
    private Vector2 currentInput;
    private float verticalVelocity;

    public GameObject raywave;
    public GameObject hand;
    public Transform handBase;
    private bool isEnable;

    [SerializeField] AudioSource RayWaveShotAudio;

    void creatRayWave()
    {
        GameObject rayWave = Instantiate(raywave, hand.transform.position, hand.transform.rotation);
        rayWave.GetComponent<Rigidbody>().velocity = speed * handBase.forward;
        RayWaveShotAudio.Play(0);
    }

    
    void Start()
    {
        animator = GetComponent<Animator>();
        charactercontroller = GetComponent<CharacterController>();

        isEnable = false;
    }

 

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 targetInput = new Vector2(moveHorizontal, moveVertical);
        currentInput = Vector2.Lerp(currentInput, targetInput, Time.deltaTime / transitionTime);

        animator.SetFloat("H", currentInput.x);
        animator.SetFloat("V", currentInput.y);

        if (Input.GetKeyDown(KeyCode.E))
        {
            //animator.SetBool("Kick", true);
            //animator.SetBool("RayWave", false);
            animator.Play("Kick");
        }
        if (Input.GetKeyDown(KeyCode.R) && !isEnable)
        {
            //animator.SetBool("RayWave", true);
            //animator.SetBool("Kick", false);
            animator.Play("RayWave");
            //creat raywave
            StartCoroutine(Waiter());
        }

        if (charactercontroller.isGrounded)
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

    private IEnumerator Waiter()
    {
        isEnable = true;

        yield return new WaitForSeconds(1.3f);

        creatRayWave();

        isEnable = false;
    }

}
