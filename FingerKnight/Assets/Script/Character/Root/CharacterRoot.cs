using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRoot : MonoBehaviour {//캐릭터 기본 스탯
    [SerializeField]
    protected EnumDate.E_Character character;
    [SerializeField]
    public EnumDate.E_CharState state;
    [SerializeField]
    protected float hp, defense, dmg, range, spd, atspd;
    [SerializeField]
    protected float hpv, dfv, dmgv, rangev, spdv, atspdv;

    [SerializeField]
    protected List<Transform> arr_Target;
    [SerializeField]
    Vector3 StPos, EndPos, Dir, MoveVec;
    [SerializeField]
    float dist;

    public GameObject stateUI;
    public Transform stateUIparent;

    private void Awake() {
    }

    public virtual void Update() {
        EnemyListSort();
        //상태별 행동 나중에 트랜스로 다시 넣자..
        if (state == EnumDate.E_CharState.MOVE) {//마우스 컨트롤에서 클릭좌표랑 클릭할때 캐릭터 위치 가져와 이동시킴
            Moving(MouseControl.Instance.DestPos);
        }
    }
    public void InitUI() {
        stateUI = UIManager.Instance.arr_UIList[(int)EnumDate.E_UIList.GAME].transform.GetChild(0).gameObject;
        stateUIparent = stateUI.transform.parent;
    }

    //기초적인 기능 넣고 베이스로 기초 먼저 발동 후 필요한거 오버라이드로 다시 작성하는식으로

    public virtual void Move() {
        state = EnumDate.E_CharState.MOVE;
        //이동부 구현
    }

    public void Moving(Vector3 endpos) {//기본적으로 특정 위치로 이동 후 적이 있으면 공격임.
        StPos = MouseControl.Instance.StPos;
        EndPos = endpos;
        MoveVec = (StPos - EndPos).normalized;

        dist = Vector3.Distance(transform.position, EndPos);

        if (EndPos != Vector3.zero) {
            if (state == EnumDate.E_CharState.MOVE) {
                if (dist > 0.01f) {//이동하는거 수정해야함
                    transform.localPosition -= MoveVec * spd * Time.deltaTime;
                }
                else {//목표점 도달 후 주변에 적 있으면 공격해야함
                    if (arr_Target != null) {
                        //공격함수 호출
                    }
                }
            }

            else if(state == EnumDate.E_CharState.ATTACK) {
                if (dist > 0.5f) {//대상까지 미도달시
                    if (arr_Target != null) {//목록에 적 있으면 공격
                        //공격함수 호출
                    }
                    else//없으면 계속 이동
                        transform.localPosition -= MoveVec * spd * Time.deltaTime;
                }
                else {//목표점 도달 후 주변에 적 있으면 공격해야함
                    if (arr_Target != null) {
                        //공격함수 호출
                    }
                }
            }
        }
    }
    void MoveStop() {
        MouseControl.Instance.InitClickPos();
    }
    public virtual void Attack() {//이동공격시 범위 내 적 소팅해서 판별 타겟팅이면 무시하고 바로 공격
        state = EnumDate.E_CharState.ATTACK;
        MoveStop();
        //이동 및 공격부 구현
    }
    
    void Attacking() {
        state = EnumDate.E_CharState.NONE;
        StartCoroutine(CAttack(atspd));
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
    }

    public virtual void StateUIOff() {//태그로 내거인지 아닌지 판별해서 띄우자
        stateUI.SetActive(false);
    }

    IEnumerator CAttack(float atspd) {//나중에..
        state = EnumDate.E_CharState.NONE;
        //공격 구현
        //리스트에서 적 불러다가 attacked 연결해주기
        yield return new WaitForSeconds(atspd);
        
        //적 있으면 다시 어택으로 바꾸고 반복시키고 없으면 논으로 바꿔
    }

    //적 타겟팅해서 소팅하는 부분, 자동으로 함
    public void EnemyListSort() {
        arr_Target.Sort(delegate (Transform t1, Transform t2) {
            return Vector3.Distance(t1.position, transform.position).CompareTo(Vector3.Distance(t2.position, transform.position));
        });
    }
    //아래부분 타겟레인지 클래스 하나 만들어서 거기에 넣어 연결해주자
    private void OnTriggerEnter2D(Collider2D other) {
        if (other != null)
            arr_Target.Add(other.transform);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other != null)
            arr_Target.Remove(other.transform);
    }
}
