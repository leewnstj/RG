using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent<Vector2> PlayerMovement;
    public UnityEvent PlayerInput;

    private void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    private void PlayerMove()
    {
        float X = Input.GetAxisRaw("Horizontal");
        PlayerMovement?.Invoke(new Vector2(X, 0));
    }

    private void PlayerJump()
    {
        PlayerInput.Invoke();
    }
}
