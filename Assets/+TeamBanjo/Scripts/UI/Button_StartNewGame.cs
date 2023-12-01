using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using System;

namespace TeamBanjo.UI
{
    public class Button_StartNewGame : MonoBehaviour
    {
        [SerializeField, Scene] private string loadingScene;
        [SerializeField, Scene] private string gameScene;
        [SerializeField] private float transitionTime = 1.0f;
        public static event Action<string> NextLevel;
        public static event Action<Scene> NextScene;

        public void OnStartNewGame()
        {
            Debug.Log("Button pressed");

            NextLevel?.Invoke(gameScene);
            NextScene?.Invoke(SceneManager.GetSceneAt(2));

            //SceneManager.LoadSceneAsync(loadingScene, LoadSceneMode.Additive);

            StartCoroutine(LoadLevel());
        }

        IEnumerator LoadLevel()
        {
            yield return new WaitForSeconds(transitionTime);

            //SceneManager.LoadSceneAsync(loadingScene, LoadSceneMode.Additive);
        }

        //IEnumerator LoadSceneAsync(string scene)
        //{
        //    AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        //    yield return null;
        //}
    }
}
