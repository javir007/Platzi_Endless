using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private const float DISTANCE = 1.6f;
    private const float TURN_SPEED = 0.05f;

    //Character Movement
    private float jump = 5f;
    private float gravity = 12f;
    private float verticalVelocity;
    private float speed = 7f;
    private int lane = 1;


    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            ChangeLane(false);
            
        }if(Input.GetKeyDown(KeyCode.RightArrow)){
            ChangeLane(true);
        }


        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if(lane == 0){
            targetPosition += Vector3.left * DISTANCE;
        }else if(lane == 2){
            targetPosition += Vector3.right * DISTANCE;
        }

        Vector3 moveTarget = Vector3.zero;

        moveTarget.x = (targetPosition - transform.position).normalized.x * speed;
        bool isGrounded = IsGrounded();

        if (isGrounded)
        {
            verticalVelocity = -0.1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {

                verticalVelocity = jump;

            }
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);

        }


        moveTarget.y = verticalVelocity;
        moveTarget.z = speed;

        //Movimiento
        controller.Move(moveTarget * Time.deltaTime);

        Vector3 dir = controller.velocity;
        dir.y = 0;

        //Rotación
        transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);



	}

    void ChangeLane(bool isRight){
        lane += (isRight) ? 1 : -1;

        lane = Mathf.Clamp(lane, 0, 2);
    }

    private bool IsGrounded()
    {
        Ray groundRay = new Ray(new Vector3(controller.bounds.center.x, (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f, controller.bounds.center.z), Vector3.down);
        return Physics.Raycast(groundRay, 0.2f + 0.1f);
    }
}
