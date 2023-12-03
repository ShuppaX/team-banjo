using System.Collections;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

namespace TeamBanjo.SceneHandling
{
    public class SceneLoadManager : MonoBehaviour
    {
        [SerializeField, Scene] private string mainMenuScene;
        [SerializeField, Scene] private string loadingScene;
        [SerializeField, Scene] private string firstLevelScene;
        [SerializeField] private Animator transitionAnimator;
        [SerializeField, AnimatorParam("transitionAnimator")] private int startAnimation;
        [SerializeField, AnimatorParam("transitionAnimator")] private int endAnimation;
        private string previousScene;
        private string currentScene;
        private string nextScene;
        private float transitionTime = 1.0f;
        private Coroutine transitionRoutine;

        private void Awake()
        {
            GetReference();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            if ( transitionAnimator != null )
            {
                StopCoroutine(WaitScreenTransitionAndLoadNextScene());
                transitionRoutine = null;
            }

            SceneManager.sceneLoaded -= OnSceneLoaded;
            RemoveNextSceneListener();
        }

        private void GetReference()
        {
            if ( transitionAnimator == null )
            {
                Debug.LogError($"{this} is missing a reference to Transition Animator!");
            }
        }

        private void RemoveNextSceneListener()
        {
            Button_LoadScene.NextScene -= OnNextScene;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Ensure that LoasingScene is not active scene
            if ( SceneManager.GetSceneAt(0).name == loadingScene )
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
            }

            previousScene = UpdatePreviousScene();
            currentScene = UpdateCurrentScene();

            // Try set listener to the NextLevel event.
            try
            {
                Button_LoadScene.NextScene += OnNextScene;
            }
            catch ( System.Exception )
            {
                Debug.LogError($"{this} couldn't get a reference to a NextScene event!");
                throw;
            }
        }

        /// <summary>
        /// When player pushes button to load next scene aka level. Updates Previous and Next Scene strings. Calls StartScreenTransition.
        /// </summary>
        /// <param name="nextScene">Name of the next scene</param>
        private void OnNextScene(string nextScene)
        {
            previousScene = UpdatePreviousScene();
            this.nextScene = nextScene;

            RemoveNextSceneListener();

            StartScreenTransition();
        }

        /// <summary>
        /// Start transtion animation and calls coroutine to wait it.
        /// </summary>
        private void StartScreenTransition()
        {
            // Start screen transition.
            transitionAnimator.SetTrigger(startAnimation);

            transitionRoutine = StartCoroutine(WaitScreenTransitionAndLoadNextScene());
        }

        /// <summary>
        /// Waits for the screen transition.
        /// After transition is covering the screen it unloads the old scene and loads the next one.
        /// Starts end transition to reveal the next scene.
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitScreenTransitionAndLoadNextScene()
        {
            // Waiting screen transition
            yield return new WaitForSecondsRealtime(transitionTime);

            // Unloading previous scene for example, Main Menu.
            SceneManager.UnloadSceneAsync(previousScene);

            // Ensure that pause is not on when loading the next scene.
            Time.timeScale = 1.0f;

            // Loading next scene for example, Level1.
            SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);

            nextScene = null;

            // End screen transition.
            transitionAnimator.ResetTrigger(startAnimation);
            transitionAnimator.SetTrigger(endAnimation);

            transitionRoutine = null;
        }

        /// <summary>
        /// Updates a string of currentScene.
        /// </summary>
        /// <returns>Current Scene</returns>
        private string UpdateCurrentScene()
        {
            string currentScene;
            currentScene = SceneManager.GetActiveScene().name;
            return currentScene;
        }

        /// <summary>
        /// Updates a string of previousScene.
        /// </summary>
        /// <returns>Previous Scene</returns>

        private string UpdatePreviousScene()
        {
            string previousScene;
            previousScene = currentScene;
            return previousScene;
        }
    }
}
