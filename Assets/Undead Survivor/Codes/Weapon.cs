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
    
    void LateUpdate()
    {
        if (GameManager.instance.player.inputVec.x != 0)
        {
            spriter.flipX = GameManager.instance.player.inputVec.x < 0;
        }
    }
    

    void Weapon0()
    {

    }
}
