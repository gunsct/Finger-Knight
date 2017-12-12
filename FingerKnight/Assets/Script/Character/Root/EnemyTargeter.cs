using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeter : MonoBehaviour {
    public CharacterRoot c_Parent;

    void Awake() {
        c_Parent = transform.parent.GetComponent<CharacterRoot>();
    }
    //아래부분 타겟레인지 클래스 하나 만들어서 거기에 넣어 연결해주자
    private void OnTriggerEnter2D(Collider2D other) {
        if (other != null)
            c_Parent.ArrTarget.Add(other.GetComponent<EnemyTargeter>().c_Parent);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other != null)
            c_Parent.ArrTarget.Remove(other.GetComponent<EnemyTargeter>().c_Parent);
    }
}
