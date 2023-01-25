using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("플레이어 기본 스텟")]
    [SerializeField] float PlayerSpeed;
    [SerializeField] float LaycastDistance;
    [SerializeField] float PlayerJumpPower;
    [SerializeField] float DashPower;

    public LayerMask layer;

    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void PlayerMove(Vector2 X)
    {
        rigid.velocity = new Vector2(X.x * PlayerSpeed, rigid.velocity.y);
    }

    public void PlayerFilp(Vector2 X)
    {
        if(X.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if(X.x == 0)
        {
            transform.localScale = transform.localScale;
        }
        else
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    public void PlayerJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, LaycastDistance, layer);
        if(Input.GetKeyDown(KeyCode.Space) && hit)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, PlayerJumpPower);
        }
    }

    public void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rigid.velocity = new Vector2(DashPower,0);
        }
    }
}
