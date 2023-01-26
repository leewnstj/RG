using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float PlayerSpeed;
    [SerializeField] float JumpDistance;
    [SerializeField] float JumpPower;

    [SerializeField] float DashPower;

    public LayerMask layer;
    private Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Dash();
    }

    private void Move()
    {
        float X = Input.GetAxisRaw("Horizontal");

        rigid.velocity = new Vector2(X * PlayerSpeed, rigid.velocity.y);
        PlayerFilp(X);
    }

    private void PlayerFilp(float X)
    {
        transform.localScale = X switch
        {
            1 => new Vector2(1, 1),
            -1 => new Vector2(-1, 1),
            _ => transform.localScale
        };
    }

    private void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, JumpDistance, layer);
        if (Input.GetKeyDown(KeyCode.Space) && hit)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, JumpPower);
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Dashing");
        }
    }
}
