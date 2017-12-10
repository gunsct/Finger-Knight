using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStateUI : DeleteSingleton<CharStateUI> {//클릭한 본인 캐릭터 머리 위에 뜰것
    [SerializeField]
    private CharacterRoot c_CR;

    public CharacterRoot CR {
        get { return c_CR; }
        set { c_CR = value; }
    }
    // Use this for initialization
    public void TransState(int sta) {
        switch ((EnumDate.E_CharState)sta) {
            case EnumDate.E_CharState.NONE:
                break;

            case EnumDate.E_CharState.MOVE:
                c_CR.Move();
                break;

            case EnumDate.E_CharState.ATTACK:
                c_CR.Attack();
                break;

            case EnumDate.E_CharState.DEFEND:
                c_CR.Defend();
                break;
        }
    }
}
