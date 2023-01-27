using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBullet : MonoBehaviour
{
    public int borderBulletNum;
    Vector3 borderBulletPos;
    private float borderBulletWidth=6;
    private float borderBulletHeight=9.5f;

    private void Awake()
    {
        if (borderBulletNum == 0)
            borderBulletPos = new Vector3(0, -borderBulletHeight, 0);
        if (borderBulletNum == 1)
            borderBulletPos = new Vector3(0, borderBulletHeight, 0);
        if (borderBulletNum == 2)
            borderBulletPos = new Vector3(-borderBulletWidth, 0, 0);
        if (borderBulletNum == 3)
            borderBulletPos = new Vector3(borderBulletWidth, 0, 0);
    }
    void Update()
    {
        transform.position = GameManager.instance.player.transform.position + borderBulletPos;
        //transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
