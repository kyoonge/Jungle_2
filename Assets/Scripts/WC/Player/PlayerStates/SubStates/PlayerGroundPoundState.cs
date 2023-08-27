using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onLand
{
    public class PlayerGroundPoundState : PlayerAbilityState
    {
        public PlayerGroundPoundState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Enter GroundPoundState");
            
            player.InputHandler.UseGroundPoundInput();
            
            startTime = Time.time;

            player.InAirState.SetIsGroundPounding();
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (!isExitingState)
            {
                
                player.SetVelocityX(0f);
                player.SetVelocityY(playerData.groundPoundVelocity);
                
                //player.SetVelocity(playerData.dashVelocity, dashDirection);

                if(player.CheckIfGrounded())
                {
                    player.RB.drag = 0f;
                    isAbilityDone = true;
                }
            }
        }

        public bool CheckIfCanGroundPound()
        {
            return !player.CheckIfGrounded();
        }
    }
}
