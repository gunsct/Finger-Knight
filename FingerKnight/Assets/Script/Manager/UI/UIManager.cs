using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : DonDeleteSingleton<UIManager> {
    public List<GameObject> arr_UIList = null;
    private Transform o_Child;
    private GameObject o_CurrentUI;
    
    public override void Init() {
        //ui 리스트화
        o_Child = transform.GetChild(0);

        for (int i = 0; i < o_Child.childCount; i++) {
            arr_UIList.Add(o_Child.GetChild(i).gameObject);
        }

        o_CurrentUI = arr_UIList[0].gameObject;

        for (int i = 1; i < o_Child.childCount; i++) {
            arr_UIList[i].SetActive(false);
        }
    }

    //게임과 로비 씬 이동 예외처리 및 상황별 유아이 로드
    public void ChangeUIList(int index) {
        if (index == 1)
            SceneLoader.Instance.SceneMove("Main");

        o_CurrentUI.SetActive(false);

        o_CurrentUI = arr_UIList[index];
        o_CurrentUI.SetActive(true);
    }
}
