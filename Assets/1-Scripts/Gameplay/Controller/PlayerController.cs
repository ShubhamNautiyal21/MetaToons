using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace SN.MetaVerse
{

    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {

        private IPlayerState _playerState;
        private Idle _idle;
        private Walk _walk;
        private Run _run;
        private Dance _dance;
        private Jump _jump;




        private CharacterController _controller;
        private Vector3 _playerVelocity;
        private bool _groundedPlayer, _isMoving;
        private bool _isSprinting = false;
        public PlayerSettingsScriptable playerSettings;



        private float _xRotation = 0f;
        private bool _isIdle = true;
        private bool _isWalking = false;
        private bool _isJumping = false;
        private bool _isDancing = false;

        private Vector3 _move;



        private void Awake()
        {

            _idle = new Idle();
            _run = new Run();
            _walk = new Walk();
            _jump = new Jump();
            _dance = new Dance();
            _playerState = _idle;
            _controller = GetComponent<CharacterController>();

        }
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;

        }
        private void Update()
        {
            _groundedPlayer = _controller.isGrounded;
            _isMoving = _controller.velocity.magnitude > 0;
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                _isDancing = !_isDancing;

                if (_isDancing)
                {
                    _playerState = _dance;
                    _playerState.OnChangedState();

                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && _groundedPlayer)
            {
                _playerVelocity.y += playerSettings.jumpHeight;
                _isJumping = true;
                ChangePlayerState(_jump);
            }
            if (_controller.velocity.y <= 0 && _isJumping)
            {
                _isJumping = false;
                ChangePlayerState(_idle);

            }
            HandleMouseLook();
            _move = HandleMovement();
        }
        private void FixedUpdate()
        {

            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            _controller.Move(_move * Time.fixedDeltaTime);
            _playerVelocity.y += playerSettings.gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.fixedDeltaTime);

        }
        void LateUpdate()
        {
            UpdatePlayerState(_move);
        }


        private void HandleMouseLook()
        {
            float mouseX = Input.GetAxis("Mouse X") * playerSettings.mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * playerSettings.mouseSensitivity * Time.deltaTime;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
            Camera.main.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        private Vector3 HandleMovement()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift) && _groundedPlayer)
            {
                _isSprinting = true;
            }
            else
            {
                _isSprinting = false;
            }

            if (_isSprinting)
            {
                return transform.right * moveX + transform.forward * moveZ * playerSettings.sprintSpeed;
            }
            else
            {
                return transform.right * moveX + transform.forward * moveZ * playerSettings.playerSpeed;
            }
        }

        private void UpdatePlayerState(Vector3 move)
        {
            if (_groundedPlayer)
            {

                if (_isDancing || _isJumping) return;

                if (move.magnitude > 0)
                {
                    if (_isSprinting)
                    {
                        ChangePlayerState(_run);
                        return;
                    }

                    ChangePlayerState(_walk);
                    return;

                }

                ChangePlayerState(_idle);
                return;
            }

        }

        private void ChangePlayerState(in IPlayerState toChange)
        {
            _playerState = toChange;
            _playerState.OnChangedState();
        }
    }

}
