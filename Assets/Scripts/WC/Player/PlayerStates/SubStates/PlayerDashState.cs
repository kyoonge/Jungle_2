using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onLand
{
    public class PlayerDashState : PlayerAbilityState
    {
        private int amountOfDashesLeft;

        private bool isDashOnApex;

        private float lastDashTime;

        private Vector2 dashDirection;
        private Vector2 dashDirectionInput;

        public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
            amountOfDashesLeft = playerData.amountOfDashes;
        }
        public override void Enter()
        {
            base.Enter();

            player.InputHandler.UseDashInput();

            isDashOnApex = playerData.isDashOnApex;

            dashDirection = Vector2.right * player.FacingDirection;
            amountOfDashesLeft--;

            //slow
            //Time.timeScale = playerData.holdTimeScale;
            
            //startTime = Time.unscaledTime;
            startTime = Time.time;
            Debug.Log("Dash Enter");
        }

        public override void Exit()
        {
            Debug.Log("Dash Exit");
            base.Exit();

            if (player.CurrentVelocity.y > 0)
            {
                player.SetVelocityY(player.CurrentVelocity.y * playerData.dashEndYMultiplier);
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if (!isExitingState)
            {
                player.SetVelocity(playerData.dashVelocity, dashDirection);

                if(Time.time >= startTime + playerData.dashTime)
                {
                    player.RB.drag = 0f;
                    isAbilityDone = true;
                    lastDashTime = Time.time;
                }
            }
        }

        public bool CheckDashCool()
        {
            if (isDashOnApex)
            {
                if (player.RB.velocity.y > 0f)
                {
                    return false;
                }
            }
            return Time.time >= lastDashTime + playerData.dashCooldown;
        }
        
        public bool CanDash()
        {
            if (amountOfDashesLeft > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ResetAmountOfDashesLeft() => amountOfDashesLeft = playerData.amountOfDashes;
        public void DecreaseAmountOfDashesLeft() => amountOfDashesLeft--;

    }

}
