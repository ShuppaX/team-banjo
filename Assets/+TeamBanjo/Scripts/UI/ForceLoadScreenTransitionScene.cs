using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TeamBanjo.UI
{
    public class ForceLoadScreenTransitionScene : MonoBehaviour
    {
        private string screenTransitionSceneName = "ScreenTransition";

        private void Awake()
        {
            if ( !SceneManager.GetSceneByName(screenTransitionSceneName).isLoaded )
            {
                SceneManager.LoadSceneAsync(screenTransitionSceneName, LoadSceneMode.Additive);
            }
        }
    }
}
