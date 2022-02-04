using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody RB;
    public float forwardSpeed =10f,reverseSpeed=5f,turnStrength=90f,gravityForce=-10f,checkRadius=0.5f,drag=4f,maxWheelTurn=22.5f;
    private float speedInput,turnInput;
    private bool isGrounded;
    public LayerMask whatIsGround;
    public Transform groundCheck,leftFrontWheel,rightFrontWheel;

    // Start is called before the first frame update
    void Start()
    {
        RB.transform.parent =null;
    }

    // Update is called once per frame
    void Update()
    {
        speedInput=0f;
        if(Input.GetAxis("Vertical")>0){
            speedInput=Input.GetAxis("Vertical")*forwardSpeed*1000f;
        }
        else if(Input.GetAxis("Vertical")<0){
            speedInput= Input.GetAxis("Vertical")*reverseSpeed*1000f;


        }
        turnInput=Input.GetAxis("Horizontal");
        if(isGrounded){
            transform.rotation =Quaternion.Euler(transform.rotation.eulerAngles +new Vector3(0f,turnInput*turnStrength*Time.deltaTime*Input.GetAxis("Vertical"),0f));
        }
        leftFrontWheel.localRotation=Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x,turnInput*maxWheelTurn,leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation=Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x,turnInput*maxWheelTurn,rightFrontWheel.localRotation.eulerAngles.z);
        transform.position=RB.transform.position;
    }
    private void FixedUpdate() {
        RaycastHit hit;
        isGrounded = Physics.Raycast(groundCheck.position, -transform.up,out hit,checkRadius,whatIsGround);
        transform.rotation =Quaternion.FromToRotation(transform.up,hit.normal)*transform.rotation;
        if (isGrounded){
            RB.drag =drag;
            if(Mathf.Abs(speedInput)>0){
                RB.AddForce(transform.forward*speedInput);

            }
            else
            {
                RB.drag=0.1f;
                RB.AddForce(Vector3.up*gravityForce*100f);
            }
        }
    }
}
