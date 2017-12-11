using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Defender {

    void Awake() {
        Inited();
    }
    
    void Inited() {
        InitUI();
        InitStat();

        hp = 20.0f + hpv;
        dmg = 2.0f + dmgv;
        defense = 2.0f + dfv;
        spd = 1.0f;
        atspd = 2.0f;
    }

    // Update is called once per frame
     void Update () {
        base.Update();
	}
}
