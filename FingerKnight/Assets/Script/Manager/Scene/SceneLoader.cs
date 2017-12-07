using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : DonDeleteSingleton<SceneLoader> {
    private AsyncOperation async_operation;
    public bool b_Loading = false;

    public void SceneMove(string sceneName) {
        StartCoroutine(LoadingScene(sceneName));
    }

    IEnumerator LoadingScene(string sceneName) {
        // next scene index
        async_operation = SceneManager.LoadSceneAsync(sceneName);
        async_operation.allowSceneActivation = false;

        while (!async_operation.isDone) {

            if (async_operation.progress == .9f) {
                async_operation.allowSceneActivation = true;
            }

            yield return null;
        }

        b_Loading = false;
    }
}
