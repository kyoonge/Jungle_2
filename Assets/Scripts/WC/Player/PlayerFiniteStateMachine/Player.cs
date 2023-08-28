using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace onLand
{
    public class Player : MonoBehaviour
    {
        #region State Variables
        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerInAirState InAirState { get; private set; }
        public PlayerLandState LandState { get; private set; }
        public PlayerGroundPoundState GroundPoundState { get; private set; }
        public PlayerDashState DashState { get; private set; }
        

        public PlayerData playerData;
        #endregion
        #region Components
        public Animator Anim { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Rigidbody2D RB { get; private set; }

        #endregion

        #region Check Transforms
        [SerializeField] 
        private Transform groundCheck;
        #endregion

        #region Other Variables
        private Vector2 workspace;
        public Vector2 CurrentVelocity { get; private set; }
        public int FacingDirection { get; private set; }

        public GameObject key;
        #endregion

        #region Unity Callback Functions
        private void Awake()
        {
            StateMachine = new PlayerStateMachine();

            IdleState = new PlayerIdleState(this, StateMachine, playerData,"idle");
            MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
            JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
            InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
            LandState = new PlayerLandState(this, StateMachine, playerData, "land");
            GroundPoundState = new PlayerGroundPoundState(this, StateMachine, playerData, "inAir");
            DashState = new PlayerDashState(this, StateMachine, playerData, "inAir");
        }

        private void Start()
        {
            // Components 연결
            Anim = transform.Find("Visual").GetComponent<Animator>();
            InputHandler = GetComponent<PlayerInputHandler>();
            RB = GetComponent<Rigidbody2D>();
            
            // 기본값 설정
            RB.gravityScale = playerData.gravityScale;
            FacingDirection = 1;

            StateMachine.Initialize(IdleState);
        }
        private void Update()
        {
            CurrentVelocity = RB.velocity;
            StateMachine.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.PhysicsUpdate();
        }
        #endregion

        #region Set Functions
        public void SetVelocityX(float velocity)
        {
            workspace.Set(velocity, CurrentVelocity.y);
            RB.velocity = workspace;
            CurrentVelocity = workspace;
        }

        public void SetVelocityY(float velocity)
        {
            workspace.Set(CurrentVelocity.x, velocity);
            RB.velocity = workspace;
            CurrentVelocity = workspace;
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            workspace = direction * velocity;
            RB.velocity = workspace;
            CurrentVelocity = workspace;
        }

        #endregion

        #region Check Functions

        public bool CheckIfGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
        }
        public void CheckIfShouldFlip(int xInput)
        {
            if(xInput !=0&&xInput != FacingDirection)
            {
                Flip();
            }
        }
        #endregion

        #region Other Functions
        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
        public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
        private void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        #endregion
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("key"))
            {
                key = other.gameObject;
                MoveState.key = other.gameObject.GetComponent<Key>();
                IdleState.key = other.gameObject.GetComponent<Key>();
                LandState.key = other.gameObject.GetComponent<Key>();
                GroundPoundState.key = other.gameObject.GetComponent<Key>();
            }
        }

        /*private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("key"))
            {
                key = null;
                MoveState.key = null;
                IdleState.key = null;
                LandState.key = null;
            }
        }*/
    }
}

