using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float jumpForce;

    [SerializeField] private float gravity;

    private float timeStartJump;

    [SerializeField] private float moveSpeed;

    private float groundPos;

    [SerializeField] private float timeForNextJump;

    [SerializeField] private String MoveControlFlagName;

    public static readonly int IDLE = 0;

    public static readonly int MOVE = 1;

    private float timeRun;

    private Animator animator;

    void Start()
    {
        timeRun = Time.time;

        groundPos = gameObject.transform.position.y;

        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        jump();
    }

    private void jump() { 

        if(Time.time - timeRun >= timeForNextJump)
        {

            setAnimation(MOVE);

            float durationJumped = Time.time - timeStartJump;

            float velocityY = (jumpForce - gravity * durationJumped) * Time.deltaTime;

            if(velocityY < 0 ) {
                Debug.Log(durationJumped);
            }

            float velocityX = moveSpeed * Time.deltaTime;

            Vector3 velocity = new Vector2(velocityX, velocityY);

            gameObject.transform.position += velocity;

            if (isInGround()) {
                timeRun = Time.time;
                setAnimation(IDLE);
            }

            

        }
        else
        {
            timeStartJump = Time.time;
        }
        
    }

    private void setAnimation(int status) {

        if (animator != null) {

            animator.SetInteger(MoveControlFlagName, status);

        }
    }

    private bool isInGround() { 

        return gameObject.transform.position.y <= groundPos;

    }


}
