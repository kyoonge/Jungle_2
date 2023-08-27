using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace onLand
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private PlayerInput playerInput;
        private Player player;
        private PlayerData playerData;
        public Vector2 RawMovementInput { get; private set; }
        public Vector2 RawDashDirectionInput { get; private set; }
        public Vector2Int DashDirectionInput { get; private set; }
        
        public int NormInputX { get; private set; }
        public int NormInputY { get; private set; }
        public bool JumpInput { get; private set; }
        public bool JumpInputStop { get; private set; }
        public bool GroundPoundInput { get; private set; }
        public bool DashInput { get; private set; }
        public bool DashInputStop { get; private set; }

        private float jumpHoldTime;
        private float dashHoldTime;
        
        private float jumpInputStartTime;
        private float dashInputStartTime;

        private void Start()
        {
            playerInput = GetComponent<PlayerInput>();
            player = GetComponent<Player>();
            
            playerData = player.playerData;
            
            jumpHoldTime = playerData.jumpInputHoldTime;
            dashHoldTime = playerData.dashInputHoldTime;
        }

        private void Update()
        {
            CheckJumpInputHoldTime();
            if (playerData.isDashOnApex)
            {
                CheckDashInputHoldTime();
            }
        }

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            RawMovementInput = context.ReadValue<Vector2>();

            NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
            NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
        }
        
        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                JumpInput = true;
                JumpInputStop = false;
                jumpInputStartTime = Time.time;
            }

            if (context.canceled)
            {
                JumpInputStop = true;
            }
        }

        public void OnGroundPoundInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                GroundPoundInput = true;
            }

            if (context.canceled)
            {
                GroundPoundInput = false;
            }
        }
        
        public void OnDashInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                DashInput = true;
                DashInputStop = false;
                dashInputStartTime = Time.time;
            }
            
            if (context.canceled)
            {
                DashInputStop = true;
            }

            //대시 방향을 방향키 인풋으로 설정
            RawDashDirectionInput = new Vector2(NormInputX, NormInputY);
            DashDirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
        }

        public void UseJumpInput() => JumpInput = false;
        public void UseGroundPoundInput() => GroundPoundInput = false;
        public void UseDashInput() => DashInput = false;

        private void CheckJumpInputHoldTime()
        {
            if (Time.time >= jumpInputStartTime + jumpHoldTime)
            {
                JumpInput = false;
            }
        }

        private void CheckDashInputHoldTime()
        {
            if(Time.time >= dashInputStartTime + dashHoldTime)
            {
                DashInput = false;
            }
        }
    }
}


