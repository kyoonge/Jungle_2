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
    public float maxHoldTime = 1f; //���ο��� �ð� (1f)
    public float holdTimeScale = 0.25f; // ���ο��Ƕ��� �ð� ������
    public float dashTime = 0.2f; // ��� ����
    public float dashVelocity = 30f;
    public float drag = 10f; //��� ���� (������ٵ��� Linear Drag)
    public float dashEndYMultiplier = 0.2f; // ��� ���� �� ���� ���ư��� �ʰ� ? �ϴ� ��
    public float distBetweenAfterImages = 0.5f; // �������̹��� ������ �Ÿ�
}
