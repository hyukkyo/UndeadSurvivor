using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))  //Area�ױװ� �ƴϸ� 
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);        //�÷��̾�� Ÿ�ϸʰ��� x��ǥ ���� (���밪)
        float diffY = Mathf.Abs(playerPos.y - myPos.y);        //�÷��̾�� Ÿ�ϸʰ��� y��ǥ ���� (���밪)

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;  //���� ������ (����?ifTrue:ifFalse)
        float dirY = playerDir.y < 0 ? -1 : 1;  //���� ������ (����?ifTrue:ifFalse)

        switch (transform.tag)
        {
            case "Ground":
                if(diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);     //40 = Ÿ�ϸ� ũ�� 2��
                }else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);     //40 = Ÿ�ϸ� ũ�� 2��
                }
                break;
            case "Enemy":
                if(coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0)); // 
                }
                break;
        }
    }

}
