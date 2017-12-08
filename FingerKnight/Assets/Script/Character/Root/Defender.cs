using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : CharacterRoot {
    public void InitStat() {
        hpv = 2.0f;
        dfv = 0.5f;
        dmgv = 0.5f;
        spdv = 0.1f;
        state = EnumDate.E_CharState.NONE;
    }

    public override void Defend() {
        defense = defense * 2f;
        state = EnumDate.E_CharState.DEFEND;
        stateUI.gameObject.SetActive(false);
    }
}
