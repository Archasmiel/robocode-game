using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    private static readonly float HEIGHT_NORMAL = 2f;
    private static readonly Vector3 CENTER_NORMAL = new Vector3(0, HEIGHT_NORMAL/2, 0);
    private static readonly float HEIGHT_CROUCH = 1.3f;
    private static readonly Vector3 CENTER_CROUCH = new Vector3(0, HEIGHT_CROUCH / 2, 0);

    [Header("Player Options")]
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float runSpeed;

    private PlayerInput inputActions;
    private CharacterController controller;
    private Animator animator;
    private Vector2 movementInput;
    private Vector3 currentMovement;
    private Quaternion rotateDirection;
    private bool isWalk;
    private bool isRun;
    private bool isCrouch = false;

    private bool prevCrouch;
    

    private void OnMovementActions(InputAction.CallbackContext context) {
        movementInput = context.ReadValue<Vector2>();
        currentMovement.x = movementInput.x;
        currentMovement.z = movementInput.y;
        isWalk = movementInput.x != 0 || movementInput.y != 0;
    }

    private void OnRun(InputAction.CallbackContext context) {
        isRun = context.ReadValueAsButton();
    }

    private void OnCrouch(InputAction.CallbackContext context) {
        prevCrouch = isCrouch;
        isCrouch = context.ReadValueAsButton();
    }

    private void Awake() {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        inputActions = new PlayerInput();

        controller.center = CENTER_NORMAL;
        controller.height = HEIGHT_NORMAL;

        inputActions.CharacterControls.Movement.started += OnMovementActions;
        inputActions.CharacterControls.Movement.performed += OnMovementActions;
        inputActions.CharacterControls.Movement.canceled += OnMovementActions;

        inputActions.CharacterControls.Run.started += OnRun;
        inputActions.CharacterControls.Run.canceled += OnRun;

        inputActions.CharacterControls.Crouch.started += OnCrouch;
        inputActions.CharacterControls.Crouch.canceled += OnCrouch;
    }

    private void OnEnable() {
        inputActions.CharacterControls.Enable();
    }

    private void OnDisable() {
        inputActions.CharacterControls.Disable();
    }

    private void PlayerRotate() {
        
        if (isWalk) {
            rotateDirection = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(currentMovement),
                Time.deltaTime * rotateSpeed
                );
            transform.rotation = rotateDirection;
        }
    }

    private Vector3 SpeedControl(Vector3 move) {
        float speed = normalSpeed;
        if (isRun) {
            speed = runSpeed;
        }
        else if (isCrouch) {
            speed = crouchSpeed;
        }

        return new Vector3(move.x * speed, move.y, move.z * speed);
        // не множимо у
    }

    private void CrouchCollider() {
        if (prevCrouch && !isCrouch) {
            controller.center = CENTER_NORMAL;
            controller.height = HEIGHT_NORMAL;
        }
        else 
        if (!prevCrouch && isCrouch) {
            controller.center = CENTER_CROUCH;
            controller.height = HEIGHT_CROUCH;
        }
    }

    private void AnimationControl() {
        animator.SetBool("isWalk", isWalk);
        animator.SetBool("isRun", isRun);
        animator.SetBool("isCrouch", isCrouch);
    }

    private void Update() {
        AnimationControl();
        CrouchCollider();
        PlayerRotate();
    }

    private void FixedUpdate() {
        
        Vector3 v3 = SpeedControl(currentMovement);
        Debug.Log(v3);
        controller.Move(v3 * Time.fixedDeltaTime);
    }

}
