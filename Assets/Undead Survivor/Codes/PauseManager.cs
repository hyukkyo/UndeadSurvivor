using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject gamePausePanel;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gamePausePanel.activeInHierarchy == false) {
                OpenMenu();
            } else {
                Continue();
            }
        }

    }

    public void OpenMenu() {
        Time.timeScale = 0f;
        gamePausePanel.SetActive(true);
    }

    public void Continue() {
        Time.timeScale = 1f;
        gamePausePanel.SetActive(false);
    }
}
