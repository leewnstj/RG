using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float EnemySpeed;
    [SerializeField] float FollowDistance;
    [SerializeField] LayerMask layer;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, FollowDistance, layer);
        if(hit.collider != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * EnemySpeed);
        }
    }
}
