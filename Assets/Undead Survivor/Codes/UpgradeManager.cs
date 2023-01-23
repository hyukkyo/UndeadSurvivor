using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

    [SerializeField] GameObject upgradePanel;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    private void Start() {
        HideButtons();
    }

    public void OpenUpgradePanel(List<UpgradeData> upgradeDatas) {
        Clean();
        Time.timeScale = 0f;
        upgradePanel.SetActive(true);

        for (int i = 0; i < upgradeDatas.Count; i++) {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }

    public void Clean() {
        for (int i = 0; i < upgradeButtons.Count; i++) {
            upgradeButtons[i].Clean();
        }
    }

    public void Upgrade(int pressedButtonID) {
        GameManager.instance.player.GetComponent<Level>().Upgrade(pressedButtonID);
        
        CloseUpgradePanel();
    }

    public void CloseUpgradePanel() {
        HideButtons();

        Time.timeScale = 1f;
        upgradePanel.SetActive(false);
    }

    public void HideButtons() {
        for (int i = 0; i < upgradeButtons.Count; i++) {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }
}
