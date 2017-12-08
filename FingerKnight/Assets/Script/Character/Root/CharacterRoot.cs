using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRoot : MonoBehaviour {//캐릭터 기본 스탯
    [SerializeField]
    protected EnumDate.E_Character character;
    [SerializeField]
    protected EnumDate.E_CharState state;
    [SerializeField]
    protected float hp, defense, dmg, range, spd;
    [SerializeField]
    protected float hpv, dfv, dmgv, rangev, spdv;

    public GameObject stateUI;

    public void InitUI() {
        stateUI = UIManager.Instance.arr_UIList[(int)EnumDate.E_UIList.GAME].transform.GetChild(0).gameObject;
        stateUI.GetComponent<CharStateUI>().c_CR = this;
    }

    public virtual void TransState(EnumDate.E_CharState sta) {
        switch (sta) {
            case EnumDate.E_CharState.NONE:
                break;

            case EnumDate.E_CharState.MOVE:
                Move();
                break;

            case EnumDate.E_CharState.ATTACK:
                Attack();
                break;

            case EnumDate.E_CharState.DEFEND:
                Defend();
                break;
        }
    }

    //기초적인 기능 넣고 베이스로 기초 먼저 발동 후 필요한거 오버라이드로 다시 작성하는식으로

    public virtual void Move() {
        state = EnumDate.E_CharState.MOVE;
        //이동부 구현
        stateUI.gameObject.SetActive(false);//이동 핑 찍고 꺼지게 바꿔
    }

    public virtual void Attack() {//이동공격시 범위 내 적 소팅해서 판별 타겟팅이면 무시하고 바로 공격
        state = EnumDate.E_CharState.ATTACK;
        //이동 및 공격부 구현
        stateUI.gameObject.SetActive(false);//공격 핑 찍고 꺼지게 바꿔
    }

    public virtual void Attacked(float dmg) {
        if (hp > 0f) {
            if (dmg - defense > 0.5f)
                hp -= dmg - defense;
            else
                hp -= 0.5f;
        }
        else {
            Destroy(gameObject);
        }
    }
    
    public virtual void Defend() {
    }

    public virtual void EnemyListing() {
    }

    public virtual void StateUIOn() {//태그로 내거인지 아닌지 판별해서 띄우자
        stateUI.gameObject.SetActive(true);
        stateUI.transform.position = transform.position;
    }

    IEnumerator CMove() {
        yield return new WaitForSeconds(0.0166666f);
    }
}
