using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IsometricPlayerController : MonoBehaviour
{
    public float movementSpeed = 3f;
    private Vector2 pointerInput, movementInput;
    public Vector2 PointerInput => pointerInput;
    public bool isAttacking;
    private WeaponParent weaponParent;
    IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rbody;
    
    [SerializeField] private InputActionReference movement, attack, pointerPosition;

    private void OnEnable() {
        attack.action.performed += PerformAttack;
    }

    private void OnDisable() {
        attack.action.performed -= PerformAttack;
    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        if (weaponParent == null)
        {
            Debug.LogError("Weapon parent is null", gameObject);
            return;
        }
        weaponParent.PerformAnAttack();
    }

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        pointerInput = GetPointerInput();
        
        Vector2 currentPos = rbody.position;

        movementInput = movement.action.ReadValue<Vector2>();
        movementInput = Vector2.ClampMagnitude(movementInput, 1);

        Vector2 playerMovement = movementInput * movementSpeed;
        Vector2 newPos = currentPos + playerMovement * Time.fixedDeltaTime;

        isoRenderer.SetDirection(playerMovement);
        rbody.MovePosition(newPos);
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
