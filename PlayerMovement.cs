using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
//script controlling player movement
public class PlayerMovement : MonoBehaviour
{
    private int frames;
    public float Hinput;
    public float Vinput;
    public float speedInput;
    public float moveSpeed;
    public bool anim0;
    public bool anim1;
    public bool anim2;
    public bool anim3;
    public bool anim4;
    public bool anim5;
    public bool anim1Trig;
    public bool anim0Trig=false;
    private Rigidbody rb;
    private Animator anim;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Setup to perform ever n-th cycle
        frames++;
        moveInput = new Vector3(Hinput, 0f, Vinput);
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0;

        Quaternion cameraRelativeRotation = Quaternion.FromToRotation(Vector3.forward, cameraForward);
        Vector3 lookToward = cameraRelativeRotation * moveInput;

        if(moveInput.sqrMagnitude > 0)
        {
            Ray lookRay = new Ray(transform.position, lookToward);
            transform.LookAt(lookRay.GetPoint(1));
        }
        //replacing moveInput.sqrtMagnitude wich is not assignable with float moveInput for descreet movement switch
        //between idle,walk,run
        if (moveInput.sqrMagnitude<2.5 && moveInput.sqrMagnitude>=0)
        {
           speedInput = 0;
        }
        if (moveInput.sqrMagnitude < 8.5 && moveInput.sqrMagnitude >= 2.5)
        {
            speedInput = 4;
        }
        if (moveInput.sqrMagnitude >=8.5)
        {
            speedInput = 10;
        }
        //moveVelocity = transform.forward * moveInput.sqrMagnitude;
        moveVelocity = transform.forward * speedInput;
        Animating();
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

    void Animating()
    {
                    //anim.SetFloat("blendSpeed", rb.velocity.magnitude);
            anim.SetFloat("blendSpeed", speedInput);
        if (frames % 50 == 0)
        {
            anim.SetBool("anim0", anim0);
            anim.SetBool("anim1", anim1);
            //anim0Trig not used for now needs to decide what bhv is better for buttons
            if (anim0)
            {
                anim0Trig = !anim0Trig;
            }
            if (anim1)
            {
                anim1Trig = !anim1Trig;
            }
            frames = 0;
        }
        
    }
}
