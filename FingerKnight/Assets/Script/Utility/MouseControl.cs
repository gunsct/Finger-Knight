using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : DonDeleteSingleton<MouseControl> {
    public Transform cam;

    Vector3 PrePos = Vector3.zero;
    public Vector3 DestPos = Vector3.zero;
    public float movespd = 20.0f;
    
    public void Down() {
        cam = Camera.main.transform;
    }

    public void Click() {
        if(CharStateUI.Instance.CR.state == EnumDate.E_CharState.MOVE)
            DestPos = Input.mousePosition;
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
