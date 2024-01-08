using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed

    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Move the character
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        // Normalize the direction vector to avoid faster diagonal movement
        direction.Normalize();

        // Move the character
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
