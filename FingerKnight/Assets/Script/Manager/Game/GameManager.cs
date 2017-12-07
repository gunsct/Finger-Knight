using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public MapSetting c_MST;
    // Use this for initialization
    void Awake () {
        c_MST.Setting();
    }
}
