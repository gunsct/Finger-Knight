using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : DonDeleteSingleton<MouseControl> {
    public Transform cam;

    Vector3 PrePos = Vector3.zero;
    public Vector3 DestPos = Vector3.zero, StPos;
    public float movespd = 20.0f;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8)) {
                if (hit.collider.tag == "Player") {
                    hit.collider.gameObject.GetComponent<CharacterRoot>().StateUIOn();
                    Debug.Log("hit player");
                }

                if (hit.collider.tag == "Enemy") {
                    if (CharStateUI.Instance.CR.state == EnumDate.E_CharState.ATTACK) {
                        CharStateUI.Instance.CR.Target = hit.collider.gameObject.GetComponent<CharacterRoot>().gameObject;
                        Debug.Log("hit enemy");
                    }
                }
            }
        }
    }

    public void Down() {
        cam = Camera.main.transform;
    }

    public void Click() {//클릭좌표와 현재 캐릭터 위치를 저장
        if (CharStateUI.Instance.CR != null) {
            Vector3 clickpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            DestPos = new Vector3(clickpos.x, clickpos.y, 0f);
            StPos = CharStateUI.Instance.CR.transform.localPosition;
        }
    }

    public void InitClickPos() {//좌표 리셋해서 캐릭터 이동 안하게 제한
        StPos = DestPos = Vector3.zero;
    }

    public void Drag() {//카메라 드래그 나중에 마우스에서 터치로 바꿔야함
        if (Input.GetMouseButton(0)) {
            if (PrePos == Vector3.zero) {
                PrePos = Input.mousePosition;
                return;
            }

            Vector2 dir = (Input.mousePosition - PrePos).normalized;
            Vector3 vec = new Vector3(dir.x, dir.y, 0f);
            
            cam.position -= vec * movespd * Time.deltaTime;

            if (cam.position.x < -2f || cam.position.x > 4.5f || cam.position.y < -8f || cam.position.y > 6f) {//화면에 가두기..
                cam.position += vec * movespd * Time.deltaTime;
            }

            PrePos = Input.mousePosition;
        }
    }
}
