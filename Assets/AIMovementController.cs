using Game.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementController : BaseObject
{
    public Rigidbody2D Rigidbody;
    public Animator Animator;
    public float MoveSpeed = 5.0f;
    private BaseObject FollowedObject = null;

    public void SetFollowedObject(BaseObject baseObject)
    {
        FollowedObject = baseObject;
    }

    public override void HandleUpdate()
    {
        HandleAnimation();
    }

    public override void HandleFixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if(FollowedObject != null)
        {
            // Rigidbody.MovePosition(MoveSpeed * Time.fixedDeltaTime * FollowedObject.transform.position);
            transform.position = Vector2.MoveTowards(transform.position, FollowedObject.transform.position, MoveSpeed * Time.fixedDeltaTime);
        }
        else
        {

        }
    }

    private void HandleAnimation()
    {

      //  if (Rigidbody.velocity.x != 0) Animator.SetBool("IsMoving", true);
      //  else Animator.SetBool("IsMoving", false);
    }


}
