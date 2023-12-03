using UnityEngine;
using UnityEngine.SceneManagement;

namespace TeamBanjo.UI
{
    public class ForceLoadScreenTransitionScene : MonoBehaviour
    {
        private string screenTransitionSceneName = "ScreenTransition";

        private void Start()
        {
            if ( !SceneManager.GetSceneByName(screenTransitionSceneName).isLoaded )
            {
                SceneManager.LoadSceneAsync(screenTransitionSceneName, LoadSceneMode.Additive);
            }
        }
    }
}
