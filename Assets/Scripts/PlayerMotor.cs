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
        moveTarget.y = verticalVelocity;
        moveTarget.z = speed;


        controller.Move(moveTarget * Time.deltaTime);




	}

    void ChangeLane(bool isRight){
        lane += (isRight) ? 1 : -1;

        lane = Mathf.Clamp(lane, 0, 2);
    }
}
