using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    Rigidbody2D rigid;
    bool back = false;
    float timeWeight = 0;
    float startSpeed = 0.02f;
    float addSpeed = 0.0001f;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float playerToBullet = Vector3.Distance(transform.position, GameManager.instance.player.transform.position);
        Vector3 PlayerDirection = (transform.position - GameManager.instance.player.transform.position) / playerToBullet;
        rigid = GetComponent<Rigidbody2D>();
        if (!back && timeWeight>= startSpeed) { 
            back = true;
            timeWeight = 0;
        }
        if (!back)
        {
            transform.position += PlayerDirection * (startSpeed - timeWeight);
            timeWeight += addSpeed;
        }
        else
        {
            transform.position -= PlayerDirection * timeWeight;
            timeWeight += addSpeed;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            back = false;
            timeWeight = 0;
            gameObject.SetActive(false);
        }
    }
}
