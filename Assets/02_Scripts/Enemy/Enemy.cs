using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector2 FollowSize;
    public LayerMask layer;
    GameObject target;
    private void Start()
    {
        target = GameObject.Find("Player");
    }
    private void Update()
    {
        PlayerFollow();        
    }
    private void PlayerFollow()
    {
        Vector2 dir;
        Collider2D Sense = Physics2D.OverlapBox(transform.position, FollowSize, 0, layer);
        if (Sense)
        {
            dir = transform.position - target.transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, FollowSize);
    }
}
