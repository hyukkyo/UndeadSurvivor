using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))  //Area테그가 아니면 
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);        //플레이어와 타일맵간의 x좌표 차이 (절대값)
        float diffY = Mathf.Abs(playerPos.y - myPos.y);        //플레이어와 타일맵간의 y좌표 차이 (절대값)

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;  //삼항 연산자 (조건?ifTrue:ifFalse)
        float dirY = playerDir.y < 0 ? -1 : 1;  //삼항 연산자 (조건?ifTrue:ifFalse)

        switch (transform.tag)
        {
            case "Ground":
                if(diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);     //40 = 타일맵 크기 2배
                }else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);     //40 = 타일맵 크기 2배
                }
                break;
            case "Enemy":

                break;
        }
    }

}
