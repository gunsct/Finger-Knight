using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UpgradeDate : DateRoot {
    public float hp , dfs, dmg, spd, atspd;

    public UpgradeDate() {
        hp = dfs = dmg = spd = atspd = 0f;
    }

    public float HP {
        get { return hp; }
        set { hp = value; }
    }
    public float DFS {
        get { return dfs; }
        set { dfs = value; }
    }
    public float DMG {
        get { return dmg; }
        set { dmg = value; }
    }
    public float SPD {
        get { return spd; }
        set { spd = value; }
    }
    public float ATSPD {
        get { return atspd; }
        set { atspd = value; }
    }
}
