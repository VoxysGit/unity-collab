using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerController : MonoBehaviour
{
    public float movementSpeed = 3f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;

    // Start is called before the first frame update
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 currentPos = rbody.position;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;

        isoRenderer.SetDirection(movement);
        rbody.MovePosition(newPos);
    }
}
