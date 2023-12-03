using NaughtyAttributes;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace TeamBanjo
{
    public class Button_LoadScene : MonoBehaviour
    {
        [SerializeField, Scene] private string nextScene;
        public static event Action<string> NextScene;
        private Button button;

        private void Awake()
        {
            GetReference();
        }

        private void GetReference()
        {
            button = GetComponent<Button>();
            if ( button == null )
            {
                Debug.LogError($"{this} is missing a reference to a Button Component!");
            }
        }

        public void OnButtonClick()
        {
            button.interactable = false;

            NextScene?.Invoke(nextScene);
        }
    }
}
