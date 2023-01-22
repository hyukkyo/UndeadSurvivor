using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour {
    
    public GameObject gameOverPanel;

    public void GameOver() {
        Debug.Log("Game over");
        gameOverPanel.SetActive(true);
    }


}
