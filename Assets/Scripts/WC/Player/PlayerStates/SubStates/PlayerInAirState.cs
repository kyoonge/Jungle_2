using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onLand
{
    public class PlayerInAirState : PlayerState
    {
        //Input
        private int xInput;
        private bool jumpInput;
        private bool jumpInputStop;
        private bool dashInput;
        private bool thrustInput;

        //Checks
        private bool isGrounded;
        private bool isJumping;

        private bool coyoteTime;

        //variables
        private float downGravity;
        private float originGravity;


        public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
            downGravity = playerData.downGravityScale;
            originGravity = playerData.GravityScale;
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = player.CheckIfGrounded();
            Debug.Log("CHeckIfGrounded: " + isGrounded);
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CheckCoyoteTime();
            CheckJumpMultiplier();
            xInput = player.InputHandler.NormInputX;
            jumpInput = player.InputHandler.JumpInput;
            jumpInputStop = player.InputHandler.JumpInputStop;
            dashInput = player.InputHandler.DashInput;

            isGrounded = player.CheckIfGrounded();

            if (isGrounded && player.CurrentVelocity.y < 0.01f)
            {
                Debug.Log("Go Down");

                //downGravity back
                player.RB.gravityScale = originGravity;
                stateMachine.ChangeState(player.LandState);
            }
            else if(jumpInput && player.JumpState.CanJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (dashInput&&player.DashState.CheckIfCanDash())
            {
                stateMachine.ChangeState(player.DashState);
            }
            else
            {
                player.CheckIfShouldFlip(xInput);
                player.SetVelocityX(playerData.movementVelocity * xInput);

                player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
                player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));
            }

            if (!isGrounded && player.CurrentVelocity.y < 0.01f)
            {

                //downGravity
                player.RB.gravityScale = downGravity;
            }
        }

        private void CheckJumpMultiplier()
        {
            if (isJumping)
            {
                if (jumpInputStop)
                {
                    player.SetVelocityY(player.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                    isJumping = false;
                }
                else if (player.CurrentVelocity.y <= 0)
                {
                    isJumping = false;
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        private void CheckCoyoteTime()
        {
            if (coyoteTime && Time.time > startTime + playerData.coyoteTime)
            {
                coyoteTime = false;
                player.JumpState.DecreaseAmountOfJumpsLeft();
            }
        }

        public void StartCototeTime() => coyoteTime = true;
        public void SetIsJumping() => isJumping = true;
    }

}