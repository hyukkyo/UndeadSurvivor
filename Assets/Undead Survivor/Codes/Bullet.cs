using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int BulletNum;
    public int dmg;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BorderBullet")
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Enemy" && BulletNum >= 3) 
        {
            gameObject.SetActive(false);
        }
    }
}
