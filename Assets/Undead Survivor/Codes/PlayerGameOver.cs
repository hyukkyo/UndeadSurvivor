using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameOver : MonoBehaviour {
    
    public GameObject gameOverPanel;

    public void GameOver() {
        Time.timeScale = 0f;
        Debug.Log("Game over");
        gameOverPanel.SetActive(true);
    }


}
