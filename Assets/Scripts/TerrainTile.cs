using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector2 playerPos = WorldScrolling.instance.player.transform.position;
        Vector2 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector2 playerDir = WorldScrolling.instance.player.movementVector;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;


        switch(transform.tag)
        {
            case "Ground":
                if(diffX > diffY)
                {
                    transform.Translate(Vector2.right * dirX * 40);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector2.up * dirY * 40);
                }
                break;
            case "Enemy":
                break;
        }

    }
}
