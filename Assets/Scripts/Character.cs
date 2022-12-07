using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    [SerializeField] StatusBar hpBar;

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            Debug.Log("»ç¸Á");
        }

        hpBar.SetState(currentHp, maxHp);

    }

    public void Heal(int amount)
    {
        if(currentHp <= 0)
        {
            return;
        }
        currentHp += amount;
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }


}
