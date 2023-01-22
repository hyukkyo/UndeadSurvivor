using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

    [SerializeField] GameObject upgradePanel;

    public void OpenUpgradePanel() {
        Time.timeScale = 0f;
        upgradePanel.SetActive(true);
    }

    public void CloseUpgradePanel() {
        Time.timeScale = 1f;
        upgradePanel.SetActive(false);
    }


}
