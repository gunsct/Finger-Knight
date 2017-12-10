using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRoot : MonoBehaviour {//캐릭터 기본 스탯
    [SerializeField]
    protected EnumDate.E_Character character;
    [SerializeField]
    public EnumDate.E_CharState state;
    [SerializeField]
    protected float hp, defense, dmg, range, spd;
    [SerializeField]
    protected float hpv, dfv, dmgv, rangev, spdv;

    [SerializeField]
    protected List<Transform> arr_Target;
    [SerializeField]
    Vector3 StPos, EndPos, Dir, MoveVec;

    public GameObject stateUI;
    public Transform stateUIparent;

    public virtual void Update() {
        EnemyListSort();

        if (state == EnumDate.E_CharState.MOVE) {
            EndPos = MouseControl.Instance.DestPos;
            Dir = (StPos - EndPos).normalized;
            MoveVec = new Vector3(Dir.x, Dir.y, 0f);

            float dist = Vector3.Distance(transform.position, EndPos);
            if (EndPos != Vector3.zero) {
                if (dist > 1f)//이동하는거 수정해야함
                    transform.position -= MoveVec * spd * Time.deltaTime * 10;
                else {
                    state = EnumDate.E_CharState.NONE;
                }
            }
        }
    }
    public void InitUI() {
        stateUI = UIManager.Instance.arr_UIList[(int)EnumDate.E_UIList.GAME].transform.GetChild(0).gameObject;
        stateUIparent = stateUI.transform.parent;
    }

    //기초적인 기능 넣고 베이스로 기초 먼저 발동 후 필요한거 오버라이드로 다시 작성하는식으로

    public virtual void Move() {
        state = EnumDate.E_CharState.MOVE;

        StPos = transform.position;

        //이동부 구현
        StateUIOff();//이동 핑 찍고 꺼지게 바꿔
    }

    public virtual void Attack() {//이동공격시 범위 내 적 소팅해서 판별 타겟팅이면 무시하고 바로 공격
        state = EnumDate.E_CharState.ATTACK;
        //이동 및 공격부 구현
        StateUIOff();//공격 핑 찍고 꺼지게 바꿔
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
        StateUIOff();
    }
    
    public virtual void StateUIOn() {//태그로 내거인지 아닌지 판별해서 띄우자
        stateUI.SetActive(true);

        CharStateUI.Instance.CR = this;
        stateUI.transform.parent = transform;
        stateUI.transform.position = transform.position;
    }

    public virtual void StateUIOff() {//태그로 내거인지 아닌지 판별해서 띄우자
        //stateUI.SetActive(false);
    }

    IEnumerator CMove() {
        yield return new WaitForSeconds(0.0166666f);
    }

    //적 타겟팅해서 소팅하는 부분, 자동으로 함
    public void EnemyListSort() {
        arr_Target.Sort(delegate (Transform t1, Transform t2) {
            return Vector3.Distance(t1.position, transform.position).CompareTo(Vector3.Distance(t2.position, transform.position));
        });
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other != null)
            arr_Target.Add(other.transform);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other != null)
            arr_Target.Remove(other.transform);
    }
}
