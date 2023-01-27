using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {

    [SerializeField] Image icon;
    [SerializeField] Text name;

    public void Set(UpgradeData upgradeData) {
        icon.sprite = upgradeData.icon;
        name.text = upgradeData.Name;
    }

    internal void Clean() {
        icon.sprite = null;
        name.text = "";
    }

}
