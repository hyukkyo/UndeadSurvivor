using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradeManager upgradePanel;

    [SerializeField] List<UpgradeData> upgrades;
    List<UpgradeData> selectedUpgrades;

    [SerializeField]List<UpgradeData> acquiredUpgrades;

    int TO_LEVEL_UP {
        get {
            return level * 1000;
        }
    }

    private void Start() {
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void AddExperience(int amount) {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void CheckLevelUp() {
        if (experience >= TO_LEVEL_UP) {

            List<UpgradeData> upgradeList = GetUpgrades(3);

            if (selectedUpgrades == null) {
                selectedUpgrades = new List<UpgradeData>();
            }
            selectedUpgrades.Clear();
            selectedUpgrades.AddRange(upgradeList);

            upgradePanel.OpenUpgradePanel(upgradeList);
            experience -= TO_LEVEL_UP;
            level += 1;
        }
    }

    public void Upgrade(int selectedUpgradeID) {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID];

        if (acquiredUpgrades == null) {
            acquiredUpgrades = new List<UpgradeData>();
        }

        GameManager.instance.player.WeaponLevel[upgradeData.WeaponNum] += 1; //upgrade weapon
        if (GameManager.instance.player.WeaponLevel[0] != 0) { // if shovel upgrade
            UpgradeShovel(GameManager.instance.player.WeaponLevel[0]);
        }
        acquiredUpgrades.Add(upgradeData);
        //upgrades.Remove(upgradeData);
    }

    public List<UpgradeData> GetUpgrades(int count) {
        List<UpgradeData> upgradeList = new List<UpgradeData>();
        List<int> GachaList = new List<int>() { 0, 1, 2, 3, 4, 5 };

        if (count > upgrades.Count) {
            count = upgrades.Count;
        }

        for (int i = 0; i < count; i++)
        {
            int rand = Random.Range(0, GachaList.Count);
            upgradeList.Add(upgrades[GachaList[rand]]);
            GachaList.RemoveAt(rand);
        }

        return upgradeList;
    }

    public void UpgradeShovel(int shovelLevel) {
        GameManager.instance.player.bulletObj0[shovelLevel-1].SetActive(true);
    }
}
