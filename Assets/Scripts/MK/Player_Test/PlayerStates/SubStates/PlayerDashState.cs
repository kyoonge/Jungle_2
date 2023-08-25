using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash { get; private set; }
    private bool isHolding;

    private float lastDashTime;

    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();

        CanDash = false;
        player.InputHandler.UseDashInput();

        isHolding = true;
        dashDirection = Vector2.right * player.FacingDirection;

        //slow
        //Time.timeScale = playerData.holdTimeScale;
        
        startTime = Time.unscaledTime;
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
            if (isHolding) // 타임스케일 조정
            {
                dashDirectionInput = player.InputHandler.DashDirectionInput;

                if (dashDirectionInput != Vector2.zero)
                {
                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right,dashDirection);
                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle-45f);

                //Dash
                if (Time.unscaledTime >= startTime + playerData.maxHoldTime)
                {
                    isHolding = false;
                    startTime = Time.time;
                    player.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                    player.RB.drag = playerData.drag;
                    player.SetVelocity(playerData.dashVelocity, dashDirection);
                }
            }
            else
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
    }

    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    public void ResetCanDash() => CanDash = true;


}
