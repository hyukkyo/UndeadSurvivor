using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject targetGameObject;
    Character targetCharacter;
    [SerializeField] float speed = 3;

    Rigidbody2D rgbd2d;

    [SerializeField] int hp = 999;
    [SerializeField] int damage = 1;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetGameObject.transform.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if(targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
