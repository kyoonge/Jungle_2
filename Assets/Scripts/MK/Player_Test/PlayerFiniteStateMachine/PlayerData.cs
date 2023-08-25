using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName="Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amoutOfJumps = 1;

    [Header("Check Variables")]
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;

    [Header("Dash State")]
    public float dashCooldown = 0.5f;
    public float maxHoldTime = 1f; //슬로우모션 시간 (1f)
    public float holdTimeScale = 0.25f; // 슬로우모션때의 시간 스케일
    public float dashTime = 0.2f; // 대시 길이
    public float dashVelocity = 30f;
    public float drag = 10f; //대시 저항 (리지드바디의 Linear Drag)
    public float dashEndYMultiplier = 0.2f; // 대시 끝날 때 높게 날아가지 않게 ? 하는 값
    public float distBetweenAfterImages = 0.5f; // 애프터이미지 사이의 거리
}
