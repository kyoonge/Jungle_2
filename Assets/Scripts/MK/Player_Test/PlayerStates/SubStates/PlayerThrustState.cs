using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrustState : PlayerAbilityState
{
    private float lastThrustTime;

    private float thrustDirection;
    private int thrustDirectionInput;
    
    private float originGravityScale;
    private float zeroGravityScale = 0f;

    public PlayerThrustState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        originGravityScale = playerData.GravityScale;
    }
    public override void Enter()
    {
        base.Enter();

        thrustDirection = player.FacingDirection;
        
        player.RB.gravityScale = zeroGravityScale;

        //slow
        //Time.timeScale = playerData.holdTimeScale;
        
        startTime = Time.unscaledTime;
        Debug.Log("Thrust Enter");
    }

    public override void Exit()
    {
        Debug.Log("Thrust Exit");
        base.Exit();
        player.RB.gravityScale = zeroGravityScale;
        /*if (player.CurrentVelocity.y > 0)
        {
            player.SetVelocityY(player.CurrentVelocity.y * playerData.dashEndYMultiplier);
        }*/
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        thrustDirectionInput = player.InputHandler.NormInputX;
        player.CheckIfShouldFlip(thrustDirectionInput);

        player.SetVelocityX(playerData.thrustVelocity * thrustDirectionInput);
        player.SetVelocityY(0f);
        
        if (!isExitingState)
        {
            if (player.InputHandler.ThrustInputStop) // 타임스케일 조정
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }
}
