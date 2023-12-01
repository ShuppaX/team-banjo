using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using TeamBanjo.UI;

namespace TeamBanjo.SceneHandling
{
    public class SceneLoadManager : MonoBehaviour
    {
        [SerializeField, Scene] private string mainMenuScene;
        [SerializeField, Scene] private string loadingScene;
        [SerializeField, Scene] private string firstLevelScene;
        [SerializeField] private string previousScene;
        [SerializeField] private string activeScene;
        [SerializeField] private string nextScene;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoad;
        }

        private void Start()
        {

        }

        private void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            // Set listeners
            try
            {
                Button_StartNewGame.NextLevel += SetNextLevel;
            }
            catch ( System.Exception )
            {
                throw;
            }

            // Debug
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);

            // Set scenes
            SetSceneNames(scene);

            // Clause gate
            if ( previousScene == "" )
            {
                return;
            }

            // Remove listeners
            try
            {
                Button_StartNewGame.NextLevel -= SetNextLevel;
            }
            catch ( System.Exception )
            {
                throw;
            }

            // Unload previus scene
            SceneManager.UnloadSceneAsync(previousScene);

            // Load next scene
            //SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);

            SetSceneNames(scene);

            // Unload LoadingScreen
            SceneManager.UnloadSceneAsync(loadingScene);
        }

        private void SetNextLevel(string scene)
        {
            nextScene = scene;
        }

        private void SetNextLevel(Scene scene)
        {
            //nextScene = scene;
            OnSceneLoad(scene, LoadSceneMode.Additive);
        }

        private void SetSceneNames(Scene scene)
        {
            previousScene = activeScene;
            activeScene = scene.name;
        }
    }
}
