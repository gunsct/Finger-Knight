using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitApp : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        SceneLoader.Instance.Init();
        UIManager.Instance.Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
