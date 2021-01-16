using Game.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameObjects.Character
{
    public class CharacterMovement : BaseObject
    {
       [SerializeField] private Animator Animator;
       [SerializeField] private Rigidbody2D Rigidbody2D;
       [SerializeField] private float RunSpeed;
        private float horizontalMovement = 0;

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
            SetDirection();
            Rigidbody2D.velocity = new Vector2(horizontalMovement, Rigidbody2D.velocity.y);
          //  if (horizontalMovement != 0) Shared.EventSystem.BuildMenuOpenTrigger.Set(false);
        }

        private void HandleAnimation()
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal") * RunSpeed;

            if (horizontalMovement != 0) Animator.SetBool("IsMoving", true);
            else Animator.SetBool("IsMoving", false);
        }

        private void SetDirection()
        {
            if(horizontalMovement != 0 )
            {
                float side = Math.Abs(horizontalMovement) / horizontalMovement;
                var tempScale = transform.localScale;
                tempScale.x = side;
                transform.localScale = tempScale;
            }
        }
    }
}
