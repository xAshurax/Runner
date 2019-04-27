using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{

    private Transform lookAt;
    private Vector3 startOffSet;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffSet = new Vector3(0, 5, 5);

    public float AnimationDuration { get => animationDuration; private set => animationDuration = value; }

    // Start is called before the first frame update
    void Start()
    {

        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffSet = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startOffSet;
        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5); 

        if(transition>1.0f)
        {

        transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffSet, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }


    }
}
