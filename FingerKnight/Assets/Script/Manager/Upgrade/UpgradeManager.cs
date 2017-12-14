using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : DonDeleteSingleton<UpgradeManager> {
    private UpgradeDate upgd;
    public UpgradeDate UPGD {
        get { return upgd; }
        set { upgd = value; }
    }

    // Use this for initialization
    public override void Init () {
        upgd = new UpgradeDate();
        Debug.Log(upgd.HP + ", " + upgd.SPD);
        string str = PlayerPrefs.GetString("Upgrade");
        if (str == "")
            DateSaveManager.Instance.ClassSave("Upgrade", upgd);
        else
            upgd = (UpgradeDate)DateSaveManager.Instance.ClassRoad("Upgrade", EnumDate.E_PrefabsDate.UPGRADE);

        Debug.Log(upgd.HP + ", " + upgd.SPD);
        Debug.Log(PlayerPrefs.GetString("Upgrade"));

    }
	
    public void UpHp() {
        upgd.HP += 1f;
        DateSaveManager.Instance.ClassSave("Upgrade", upgd);
    }
    public void UpDfs() {
        upgd.DFS += 1f;
        DateSaveManager.Instance.ClassSave("Upgrade", upgd);
    }
    public void UpDmg() {
        upgd.DMG += 1f;
        DateSaveManager.Instance.ClassSave("Upgrade", upgd);
    }
    public void Upspd() {
        upgd.SPD += 1f;
        DateSaveManager.Instance.ClassSave("Upgrade", upgd);
    }
    public void UpAtspd() {
        upgd.ATSPD += 1f;
        DateSaveManager.Instance.ClassSave("Upgrade", upgd);
    }
}
