using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStateUI : MonoBehaviour {//클릭한 본인 캐릭터 머리 위에 뜰것
    public CharacterRoot c_CR;

    // Use this for initialization
    public void Move() {
        c_CR.Move();
    }
    public void Attack() {
        c_CR.Attack();
    }
    public void Defend() {
        c_CR.Defend();
    }
}
