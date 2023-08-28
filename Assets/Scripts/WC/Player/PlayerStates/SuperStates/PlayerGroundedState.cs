using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onLand
{
    public class PlayerGroundedState : PlayerState
    {
        protected int xInput;
        private bool jumpInput;
        private bool groundPoundInput;
        private bool dashInput;
        
        private bool isGrounded;
    
        public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }
    
        public override void DoChecks()
        {
            base.DoChecks();
            isGrounded = player.CheckIfGrounded();
        }
    
        public override void Enter()
        {
            base.Enter();
    
            player.JumpState.ResetAmountOfJumpsLeft();
            player.DashState.ResetAmountOfDashesLeft();
        }
    
        public override void Exit()
        {
            base.Exit();
        }
    
        public override void LogicUpdate()
        {
            base.LogicUpdate();
    
            xInput = player.InputHandler.NormInputX;
            jumpInput = player.InputHandler.JumpInput;
            dashInput = player.InputHandler.DashInput;
    
            if (jumpInput && player.JumpState.CanJump())
            {
                stateMachine.ChangeState(player.JumpState);
            }
            else if (dashInput && player.DashState.CanDash() && player.DashState.CheckDashCool())
            {
                stateMachine.ChangeState(player.DashState);
            }
            /*else if (groundPoundInput && player.GroundPoundState.CheckIfCanGroundPound())
            {
                stateMachine.ChangeState(player.GroundPoundState);
            }*/
            else if (!isGrounded)
            {
                player.InAirState.StartCototeTime();
                stateMachine.ChangeState(player.InAirState);
            }
        }
    
        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }

}
