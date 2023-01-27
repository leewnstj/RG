using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float EnemySpeed;
    [SerializeField] float FollowDistance;
    [SerializeField] float EnemyAttackDis;
    [SerializeField] Vector2 HitBox;
    [SerializeField] LayerMask layer;
    private Animator anim;
    private PlayerHP playerHP;

    public bool canAttack;

    private void Start()
    {
        canAttack = false;
        anim = GetComponent<Animator>();
        playerHP = GetComponent<PlayerHP>();
    }

    private void Update()
    {
        FollowPlayer();
        EnemyAttack();
    }

    private void FollowPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + (FollowDistance/2), transform.position.y), 
            Vector2.left, FollowDistance, layer);
        RaycastHit2D attack = Physics2D.Raycast(new Vector2(transform.position.x + (EnemyAttackDis / 2), transform.position.y), 
            Vector2.left, EnemyAttackDis, layer);

        if(hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * EnemySpeed);
            if(hit.collider.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
            if (attack)
            {
                canAttack = true;
            }
            else
            {
                canAttack = false;
            }
        }
    }

    private void EnemyAttack()
    {
        if (canAttack)
        {
            anim.SetBool("Attack", true);
        }
    }

    public void StopAttack()
    {
        Collider2D hitBox = Physics2D.OverlapBox(transform.position, HitBox, 0, layer);
        anim.SetBool("Attack", false);
        
        if (hitBox)
        {
            playerHP.PlayerCurrentHP -= 10;
        }
        
        canAttack = false;
    }
}
