using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onLand
{
    public class PlayerLandState : PlayerGroundedState
    {
        public GameObject key;
        public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }

        public override void Enter()
        {
            base.Enter();
            if (key != null)
            {
                key.GetComponent<Key>().judgeKey.LandJudge();
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isExitingState)
            {
                if (xInput != 0)
                {
                    stateMachine.ChangeState(player.MoveState);
                }
                else if (isAnimationFinished)
                {
                    stateMachine.ChangeState(player.IdleState);
                }
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }

}
