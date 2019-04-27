using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 8.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12;
    private float maxHeight = 3;
    private bool canJump = true;
    private CameraMotor camara;
    private float jumpSpeed = 300;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time<camara.AnimationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;
        
        if(controller.isGrounded)
        {
            verticalVelocity = -0.5f;
            canJump = true;
        } else if (canJump == false)
        {
            verticalVelocity -= gravity*Time.deltaTime;
        }

        if(Input.GetMouseButton(0))
        {
            if (canJump)
            {
                verticalVelocity = jumpSpeed * Time.deltaTime ;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            canJump = false;
        }

        if(transform.position.y>=maxHeight)
        {
            canJump = false;
        }
        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;

        moveVector.x = Input.acceleration.x * speed;

        moveVector.y = verticalVelocity;

        moveVector.z = speed;
         

        controller.Move(moveVector*Time.deltaTime);
    }
}
