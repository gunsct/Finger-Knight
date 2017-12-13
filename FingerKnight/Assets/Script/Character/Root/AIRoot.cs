using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRoot : MonoBehaviour {
    public CharacterRoot c_Parent;

    private void Awake() {
        c_Parent = transform.parent.GetComponent<CharacterRoot>();

        AllTartgeting();
    }

    private void Update() {
    }
    void AllTartgeting() {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        c_Parent.Target = targets[Random.Range(0, targets.Length)];
        c_Parent.state = EnumDate.E_CharState.ATTACK;
    }
}
