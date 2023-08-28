using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace onLand
{
    [CreateAssetMenu(fileName ="newPlayerData", menuName="Data/Player Data/Chan Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Default")]
        public float gravityScale = 5f;
        
        [Header("Move State")]
        public float movementVelocity = 10f;

        [Header("Jump State")]
        public float jumpInputHoldTime = 0.2f;
        public float jumpVelocity = 15f;
        public int amoutOfJumps = 1;
        public float coyoteTime = 0.2f;
        public float variableJumpHeightMultiplier = 0.5f;
        public float downGravityScale = 7f;
        
        [Header("GroundPound State")]
        public float groundPoundVelocity = -30f;

        [Header("Dash State")] 
        public bool isDashOnApex = false;
        public float dashInputHoldTime = 0.2f;
        public int amountOfDashes = 1;
        public float dashCooldown = 0.5f;
        public float dashTime = 0.2f; // 대시 길이
        public float dashVelocity = 30f;
        public float dashEndYMultiplier = 0.2f; // 대시 종료 시 튕김 보정
        public float distBetweenAfterImages = 0.5f; // 애프터이미지 사이의 거리
        
        [Header("Check Variables")]
        public float groundCheckRadius;
        public LayerMask whatIsGround;

        [Header("In Air State")]
        public float inAirVelocity = 9f;

    }
}
