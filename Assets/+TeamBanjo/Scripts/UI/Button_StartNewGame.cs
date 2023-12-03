using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NaughtyAttributes;

namespace TeamBanjo.UI
{
    public class Button_StartNewGame : MonoBehaviour
    {
        [SerializeField, Scene] private string gameScene;
        public static event Action<string> NextScene;
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            if ( button == null )
            {
                Debug.LogError($"{this} is missing a reference to a Button Component!");
            }
        }

        public void OnStartNewGame()
        {
            button.interactable = false;

            NextScene?.Invoke(gameScene);
        }
    }
}
