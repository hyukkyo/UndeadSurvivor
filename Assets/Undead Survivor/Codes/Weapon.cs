using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    SpriteRenderer spriter;
    int WeaponNumber;   //0~5
    int WeaponLevel;    //MaxLevel = 6

    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        spriter.flipX = GameManager.instance.player.spriter.flipX;

    }

    void Weapon0()
    {

    }
}
