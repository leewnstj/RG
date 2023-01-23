using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float PlayerSpeed;
    private Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void PlayerMove(Vector2 X)
    {
        rigid.velocity = new Vector2(X.x, rigid.velocity.y) * PlayerSpeed;
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
}
