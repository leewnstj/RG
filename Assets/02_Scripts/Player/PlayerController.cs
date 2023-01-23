using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent<Vector2> PlayerMovement;

    private void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float X = Input.GetAxisRaw("Horizontal");
        PlayerMovement?.Invoke(new Vector2(X, 0));
    }
}
